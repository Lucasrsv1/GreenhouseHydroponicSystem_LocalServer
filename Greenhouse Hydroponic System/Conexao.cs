/* 
 * Created by Lucas Rassilan Vilanova;
 * This Form starts connection with Arduino, auto detect the board and allow the user to configure the connection.
 * Also, all communication is done by this Form using the communication protocol documented next.
 * 
 * Comms Protocol:
 * Este protocolo utiliza um conjunto de 6 bytes;
 * Byte 0: identifica o início de um novo comando e é uma constante definida como Convert.ToByte(16);
 * Byte 1: identifica o comando,
 *  + 126: suspende a atividade da placa,
 *  + 127: solicita um handshake para confirmar a identidade da placa,
 *  + 128: envia as informações do plano da empresa,
 *  + 129: inicializa um controle,
 *  + 130: inicializa uma estatística,
 *  + 131: envia uma ordem a placa,
 *  + 132: altera um controle,
 *  + 133: solicita a atualização de todos os controles,
 *  + 134: solicita a atualização de todas as estatísticas;
 * Byte 2: primeiro parâmetro (ignorado nos comandos 126, 133 e 134),
 *  + 127: primeiro número da requisição de confirmação de identidade da placa
 *  + 128: quantidade de estatísticas do plano,
 *  + 129: identifica o pino do Arduino,
 *  + 130: identifica o pino do Arduino,
 *  + 131: id da ordem,
 *  + 132: identifica o pino do Arduino;
 * Byte 3: segundo parâmetro (ignorado nos comandos 126, 127, 133 e 134),
 *  + 127: segundo número da requisição de confirmação de identidade da placa
 *  + 128: quantidade de controles do plano,
 *  + 129: estado do controle,
 *  + 130: tipo de leitura da estatística,
 *  + 131: identifica o pino do Arduino,
 *  + 132: estado do controle;
 * Byte 4: terceiro parâmetro (ignorado nos comandos 126, 127, 128, 129, 130, 132, 133 e 134),
 *  + 127: terceiro número da requisição de confirmação de identidade da placa
 *  + 131: estado do controle;
 * Byte 5: identifica o fim do comando e o valida pela confirmação de checksum.
 * 
 */

using System;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace Greenhouse_Hydroponic_System {
	public partial class Conexao : Form {
		public static int Checksum (int[] input) {
			byte[] inputBytes = new byte[input.Length];
			for (int i = 0; i < input.Length; i++)
				inputBytes[i] = Convert.ToByte(input[i]);

			return Checksum(inputBytes);
		}

		public static int Checksum (byte[] input) {
			int checksum = 0;
			for (int i = 0; i < input.Length; i++)
				checksum += input[i];

			checksum &= 0xFF;
			return checksum;
		}

		public Conexao () {
			InitializeComponent();
			menu.SetParent(this);

			random = new Random();
			Connected = false;
			handshake = 0;
			BaudRate = 9600;
			PortName = "-";
			IsLeonardo = "NÃO";
			LastRead = "-";
			LastCommand = "-";
		}

		public bool SendMessage (int cmd, int param0, int param1, int param2) {
			// Send message to Arduino using the Comms Protocol
			byte[] message = new byte[6] { 16, 0, 0, 0, 0, 0 };
			message[5] = Convert.ToByte(handshake);

			try {
				// Before sending
				switch (cmd) {
					case 127:
						LastCommand = "handshake request";
						break;
					case 128:
						LastCommand = "send plan information";
						break;
					case 129:
						LastCommand = "create controller pin " + param0 + (param1 == 1 ? " ON" : " OFF");
						break;
					case 131:
						LastCommand = "send order to set pin " + param1 + (param2 == 1 ? " ON" : " OFF");
						break;
				}

				message[1] = Convert.ToByte(cmd);
				message[2] = Convert.ToByte(param0);
				message[3] = Convert.ToByte(param1);
				message[4] = Convert.ToByte(param2);
				message[5] = Convert.ToByte(Checksum(message));
				//Console.WriteLine("Send: " + message[0] + ", " + message[1] + ", " + message[2] + ", " + message[3] + ", " + message[4] + ", " + message[5] + " [OK]");
				serialPort.Write(message, 0, 6);

				// After sent
				switch (cmd) {
					case 126:
						LastCommand = "Arduino shutdown";
						Login.controlesIntance.SuspendArduino();
						break;
				}

				if (InvokeRequired)
					Invoke(new Action(UpdateConfigInfo));
				else
					UpdateConfigInfo();

				return true;
			} catch {
				return false;
			}
		}

		private int handshake;
		private Random random;

		public bool Connected { get; private set; }
		public int BaudRate { get; private set; }
		public string PortName { get; private set; }
		public string IsLeonardo { get; private set; }
		public string LastRead { get; private set; }
		public string LastCommand { get; private set; }

		private void UpdateConfigInfo () {
			string status = (Connected) ? "CONECTADO" : "DESCONECTADO";
			currentConfig.Text = "Estado: " + status + "\nPorta: " + PortName + "\nTaxa de Transmissão: " + BaudRate.ToString() + "\nArduino Leonardo: " + IsLeonardo + "\nLeitura Mais Recente: " + LastRead + "\nComando Mais Recente: " + LastCommand;
		}

		private bool DetectArduino () {
			int[] paramArray = new int[3];
			for (int i = 0; i < 3; i++)
				paramArray[i] = random.Next(0, 256);

			if (SendMessage(127, paramArray[0], paramArray[1], paramArray[2])) {
				Thread.Sleep(1000);
				int returnASCII;
				int checksum = Checksum(paramArray);
				string returnMessage = "";
				for (int toRead = serialPort.BytesToRead; toRead > 0; toRead--) {
					returnASCII = serialPort.ReadByte();
					returnMessage += Convert.ToChar(returnASCII);
				}

				string rightAnswer = "Hello from Arduino running Greenhouse_Hydroponic_System_Lowest_Layer [" + checksum.ToString() + "]";
				if (returnMessage.Contains(rightAnswer)) {
					LastRead = "handshake from Arduino";
					handshake = checksum;
					return true;
				} else if (returnMessage.Length > 0) {
					LastRead = returnMessage;
					return false;
				} else {
					return false;
				}
			} else {
				return false;
			}
		}

		private void AutoIdentifyArduino () {
			string[] ports = SerialPort.GetPortNames();
			foreach (var port in ports) {
				int baud = (int)baudRate.Value;
				bool isLeonardo = leonardo.Text == "SIM";

				if (baud < 300)
					baud = 9600;

				if (serialPort.IsOpen) {
					if (Connected)
						SendMessage(126, 0, 0, 0);

					try {
						serialPort.Close();
					} catch { }
				}

				serialPort.PortName = port;
				serialPort.BaudRate = baud;
				serialPort.DtrEnable = isLeonardo;
				serialPort.RtsEnable = isLeonardo;

				Connected = false;
				handshake = 0;
				BaudRate = baud;
				PortName = port;
				IsLeonardo = (isLeonardo) ? "SIM" : "NÃO";

				if (InvokeRequired)
					Invoke(new Action(UpdateConfigInfo));
				else
					UpdateConfigInfo();

				try {
					serialPort.Open();
					Connected = DetectArduino();
					if (Connected)
						SendMessage(128, Geral.EstatisticasPlano(), Geral.ControlesPlano(), 0);
					else
						handshake = 0;

					if (InvokeRequired)
						Invoke(new Action(UpdateConfigInfo));
					else
						UpdateConfigInfo();
				} catch { }
			}

			if (!Connected)
				MessageBox.Show("Nenhum Arduino foi identificado pela pesquisa automática! Certifique-se de que a placa está conectada ao computador. Caso o problema persista, tente conectar manualmente informando as configurações.", "Erro ao identificar o Arduino", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void leonardo_Click (object sender, EventArgs e) {
			if (leonardo.Text == "SIM") {
				leonardo.Text = "NÃO";
				leonardo.BackColor = Color.FromArgb(224, 100, 86);
			} else {
				leonardo.Text = "SIM";
				leonardo.BackColor = Color.FromArgb(101, 178, 92);
			}
		}

		private void salvar_Click (object sender, EventArgs e) {
			int baud = (int)baudRate.Value;
			string com = portName.Text;
			bool isLeonardo = leonardo.Text == "SIM";

			if (baud < 300 || com.Length < 3) {
				MessageBox.Show("Valores inválidos! Verifique as configurações informadas.", "Erro ao salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (serialPort.IsOpen) {
				if (Connected)
					SendMessage(126, 0, 0, 0);

				try {
					serialPort.Close();
				} catch { }
			}

			serialPort.PortName = com;
			serialPort.BaudRate = baud;
			serialPort.DtrEnable = isLeonardo;
			serialPort.RtsEnable = isLeonardo;

			Connected = false;
			handshake = 0;
			BaudRate = baud;
			PortName = com;
			IsLeonardo = (isLeonardo) ? "SIM" : "NÃO";

			if (InvokeRequired)
				Invoke(new Action(UpdateConfigInfo));
			else
				UpdateConfigInfo();

			try {
				serialPort.Open();
				if (DetectArduino()) {
					Connected = true;
					SendMessage(128, Geral.EstatisticasPlano(), Geral.ControlesPlano(), 0);
				} else {
					Connected = false;
					handshake = 0;
					MessageBox.Show("Arduino não identificado nesta porta serial! Verifique as configurações informadas.", "Erro ao salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				if (InvokeRequired)
					Invoke(new Action(UpdateConfigInfo));
				else
					UpdateConfigInfo();
			} catch {
				MessageBox.Show("Erro ao conectar a esta porta serial! Verifique as configurações informadas.", "Erro ao salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void auto_Click (object sender, EventArgs e) {
			AutoIdentifyArduino();
		}

		private void serialPort_DataReceived (object sender, SerialDataReceivedEventArgs e) {
			if (Connected) {
				string answer = serialPort.ReadLine().Replace(serialPort.NewLine, "").Replace("\r", "");
				LastRead = answer;
				Console.WriteLine(answer + " [OK]");

				if (answer.Contains("initialized")) {
					int pin;
					int.TryParse(answer.Substring(19, answer.Substring(19).IndexOf(" ")), out pin);

					foreach (Ctrl controller in Login.controlesIntance.controllers) {
						if (controller.Rele_Pin == pin) {
							controller.Started = true;
							break;
						}
					};
				} else if (answer.Contains("executed")) {
					int id;
					int.TryParse(answer.Substring(6, answer.Substring(6).IndexOf(":")), out id);

					foreach (Order order in Login.controlesIntance.orders) {
						if (order.Local_Id == id) {
							order.Executed();
							break;
						}
					};
				}

				if (InvokeRequired)
					Invoke(new Action(UpdateConfigInfo));
				else
					UpdateConfigInfo();
			}
		}
	}
}