/* 
 * Comms Protocol:
 * Este protocolo utiliza um conjunto de 6 bytes;
 * Byte 0: identifica o início de um novo comando e é uma constante definida como Convert.ToByte(16);
 * Byte 1: identifica o comando,
 *  + 127: solicita um handshake para confirmar a identidade da placa,
 *  + 128: envia as informações do plano da empresa,
 *  + 129: inicializa um controle,
 *  + 130: inicializa uma estatística,
 *  + 131: envia uma ordem a placa,
 *  + 132: altera um controle,
 *  + 133: solicita a atualização de todos os controles,
 *  + 134: solicita a atualização de todas as estatísticas;
 * Byte 2: primeiro parâmetro (ignorado nos comandos 127, 133 e 134),
 *  + 128: quantidade de estatísticas do plano,
 *  + 129: identifica o pino do Arduino,
 *  + 130: identifica o pino do Arduino,
 *  + 131: identifica o pino do Arduino,
 *  + 132: identifica o pino do Arduino;
 * Byte 3: segundo parâmetro (ignorado nos comandos 127, 133 e 134),
 *  + 128: quantidade de controles do plano,
 *  + 129: estado do controle,
 *  + 130: tipo de leitura da estatística,
 *  + 131: id da ordem,
 *  + 132: estado do controle;
 * Byte 4: terceiro parâmetro (ignorado nos comandos 127, 128, 129, 130, 132, 133 e 134),
 *  + 131: estado do controle;
 * Byte 5: identifica o fim do comando, mas é redundante;
 * 
 */

using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace Greenhouse_Hydroponic_System {
	public partial class Conexao : Form {
		public Conexao () {
			InitializeComponent();
			menu.SetParent(this);

			Connected = false;
			BaudRate = 9600;
			PortName = "-";
			IsLeonardo = "NÃO";
			LastRead = "-";
			LastCommand = "-";
		}

		public void SendMessage () {
			// Send message to Arduino using the Comms Protocol
		}

		public bool Connected { get; private set;}
		public int BaudRate { get; private set; }
		public string PortName { get; private set; }
		public string IsLeonardo { get; private set; }
		public string LastRead { get; private set; }
		public string LastCommand { get; private set; }

		private void UpdateConfigInfo () {
			string status = (Connected) ? "CONECTADO" : "DESCONECTADO";
			Console.WriteLine("Estado: " + status + "\nPorta: " + PortName + "\nTaxa de Transmissão: " + BaudRate.ToString() + "\nArduino Leonardo: " + IsLeonardo + "\nLeitura Mais Recente: " + LastRead + "\nComando Mais Recente: " + LastCommand);
			currentConfig.Text = "Estado: " + status + "\nPorta: " + PortName + "\nTaxa de Transmissão: " + BaudRate.ToString() + "\nArduino Leonardo: " + IsLeonardo + "\nLeitura Mais Recente: " + LastRead + "\nComando Mais Recente: " + LastCommand;
		}

		private bool DetectArduino () {
			return false;
		}

		private void AutoIdentifyArduino () {
			string[] ports = SerialPort.GetPortNames();
			foreach (var port in ports) {
				int baud = (int)baudRate.Value;
				bool isLeonardo = leonardo.Text == "SIM";

				if (baud < 300)
					baud = 9600;

				if (serialPort.IsOpen) {
					try {
						serialPort.Close();
					} catch { }
				}

				serialPort.PortName = port;
				serialPort.BaudRate = baud;
				serialPort.DtrEnable = isLeonardo;
				serialPort.RtsEnable = isLeonardo;

				Connected = false;
				BaudRate = baud;
				PortName = port;
				IsLeonardo = (isLeonardo) ? "SIM" : "NÃO";
				UpdateConfigInfo();

				try {
					serialPort.Open();
					Connected = DetectArduino();
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
				try {
					serialPort.Close();
				} catch { }
			}

			serialPort.PortName = com;
			serialPort.BaudRate = baud;
			serialPort.DtrEnable = isLeonardo;
			serialPort.RtsEnable = isLeonardo;

			Connected = false;
			BaudRate = baud;
			PortName = com;
			IsLeonardo = (isLeonardo) ? "SIM" : "NÃO";
			UpdateConfigInfo();

			try {
				serialPort.Open();
				if (DetectArduino()) {
					Connected = true;
				} else {
					Connected = false;
					MessageBox.Show("Arduino não identificado nesta porta serial! Verifique as configurações informadas.", "Erro ao salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				UpdateConfigInfo();
			} catch {
				MessageBox.Show("Erro ao conectar a esta porta serial! Verifique as configurações informadas.", "Erro ao salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void auto_Click (object sender, EventArgs e) {
			AutoIdentifyArduino();
		}
	}
}