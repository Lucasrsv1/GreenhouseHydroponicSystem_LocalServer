using LRV_Utilities.DBMS;
using LRV_Utilities.Cryptography;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Greenhouse_Hydroponic_System {
	public enum Forms { Geral, Controles, Estatisticas, Conexao };

	public partial class Login : Form {
		public static readonly string passwordHash = "L$C92D9i2{VGsOJ#}cmLRV*ikº6Rq#e[";
		public static readonly string saltKey = "0eJMBHj#aoulºlrvKO$Aw5¢m£mm#I%rd&?U/qV9]F/jgB{[Mt/a{ws}9lRvC0+v;r";
		public static readonly string viKey = "2g£7.C$#B5f|eEml";

		public static string offlineUser = "greenhouse";
		public static string offlinePassword = "miVRLKzz666r53Pk";

		public static Login loginIntance;
		public static MySQLManager online;
		public static MySQLManager offline;

		private static string[] contasColumns = new string[] { "id", "empresas_id", "usuario", "primeiro_nome", "sobrenome", "tipo", "email", "telefones", "em_uso" };
		private static string[] empresaColumns = new string[] { "id", "razao_social", "nome", "cnpj", "inscricao_estadual", "endereco", "bairro", "cidade", "estado", "cep", "email", "telefones", "responsavel" };

		public static void Exit (object sender = null, EventArgs e = null) {
			loginIntance.Close();
		}

		public static void ResetMessageBoxButtons () {
			MessageBoxManager.Unregister();
			MessageBoxManager.Abort = "Abortar";
			MessageBoxManager.Cancel = "Cancelar";
			MessageBoxManager.Ignore = "Ignorar";
			MessageBoxManager.No = "Não";
			MessageBoxManager.OK = "OK";
			MessageBoxManager.Retry = "Repetir";
			MessageBoxManager.Yes = "Sim";
			MessageBoxManager.Register();
		}

		public static void LoadForm (Forms load, Form close = null) {
			Form form;
			switch (load) {
				case Forms.Geral:
					form = new Geral();
					break;
				case Forms.Controles:
					form = new Controles();
					break;
				case Forms.Estatisticas:
					form = new Estatisticas();
					break;
				case Forms.Conexao:
					form = new Conexao();
					break;
				default:
					return;
			}

			if (close != null) {
				if (close.WindowState != FormWindowState.Maximized) {
					form.Location = close.Location;
					form.Size = close.Size;
				} else {
					form.WindowState = FormWindowState.Maximized;
				}

				close.FormClosed -= Exit;
				close.Close();
			} else if (loginIntance.Visible) {
				form.Location = loginIntance.Location;
				form.Size = loginIntance.Size;
				loginIntance.Hide();
			}

			form.Show();
			form.FormClosed += Exit;
		}

		public static void DatabaseStructureError (string title) {
			MessageBox.Show("Erro na estrutura do banco de dados online. Erro: " + ((online.Error != null) ? online.Error.Message : "Indefinido."), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
			Exit();
		}

		public static void UpdateEmpresa (string[] newEmpresa, string[] oldEmpresa = null) {
			if (oldEmpresa == null) {
				offline.Select("SELECT * FROM empresas WHERE id = " + newEmpresa[0]);
				if (offline.NumRows == 1)
					oldEmpresa = offline.SelectResult[0];
				else {
					MessageBox.Show("Empresa não encontrada na base de dados local.", "Erro ao atualizar dados da empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			List<string> toUpdateValues = new List<string>();
			List<string> toUpdateColumns = new List<string>();

			for (int i = 0; i < newEmpresa.Length; i++) {
				if (newEmpresa[i] != oldEmpresa[i]) {
					toUpdateColumns.Add(empresaColumns[i]);
					toUpdateValues.Add(newEmpresa[i]);
				}
			}

			if (toUpdateValues.Count > 0) {
				offline.Update("empresas", toUpdateColumns.ToArray(), toUpdateValues.ToArray(), "id = " + newEmpresa[0]);
				if (offline.AffectedRows != 1) {
					DialogResult result = MessageBox.Show("Não foi possível atualizar as informações da sua empresa.\nErro: " + ((offline.Error != null) ? offline.Error.Message : "Indefinido."), "Empresa não atualizada", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
					if (result == DialogResult.Retry)
						UpdateEmpresa(newEmpresa, oldEmpresa);
				}
			}
		}

		public static void UpdateContas (string empresas_id) {
			List<string> toDeleteIds = new List<string>();
			List<string> toUpdateIds = new List<string>();
			List<string[]> toInsertValues = new List<string[]>();
			List<List<string>> toUpdateValues = new List<List<string>>();
			List<List<string>> toUpdateColumns = new List<List<string>>();

			offline.Select("SELECT * FROM contas WHERE empresas_id = " + empresas_id + " ORDER BY id ASC");
			online.Select("SELECT " + string.Join(", ", contasColumns) + " FROM contas WHERE empresas_id = " + empresas_id + " ORDER BY id ASC");
			if (online.NumRows <= 0)
				DatabaseStructureError("Nenhuma conta encontrada para a empresa");

			int offlineIndex = 1;
			foreach (string[] onRow in online.SelectResult.Skip(1)) {
				if (offline.NumRows <= 0) {
					//Insert All:
					toInsertValues = new List<string[]>(online.SelectResult.Skip(1));
					break;
				} else if (offlineIndex >= offline.NumRows + 1) {
					//Insert Remain:
					toInsertValues.Add(onRow);
					continue;
				}

				ActionCheck:
				string[] offRow = offline.SelectResult[offlineIndex];
				if (int.Parse(onRow[0]) < int.Parse(offRow[0])) {
					//Insert lower:
					toInsertValues.Add(onRow);
				} else if (onRow[0] == offRow[0]) {
					//Check for Update:
					List<string> currentC = new List<string>();
					List<string> currentV = new List<string>();
					for (int i = 1; i < onRow.Length; i++) {
						if (onRow[i] != offRow[i]) {
							currentC.Add(contasColumns[i]);
							currentV.Add(onRow[i]);
						}
					}

					if (currentC.Count > 0) {
						//Update:
						toUpdateIds.Add(onRow[0]);
						toUpdateColumns.Add(currentC);
						toUpdateValues.Add(currentV);
					}

					offlineIndex++;
				} else {
					//Delete lower:
					toDeleteIds.Add(offRow[0]);
					offlineIndex++;
					goto ActionCheck;
				}
			}

			while (offlineIndex < offline.NumRows + 1) {
				toDeleteIds.Add(offline.SelectResult[offlineIndex][0]);
				offlineIndex++;
			}

			MessageBoxManager.Cancel = "Ignorar";
			if (toInsertValues.Count > 0) {
				offline.InsertInto("contas", contasColumns, toInsertValues.ToArray());
				if (offline.AffectedRows != toInsertValues.Count) {
					DialogResult result = MessageBox.Show("Não foi possível inserir todas as contas da sua empresa.\nErro: " + ((offline.Error != null) ? offline.Error.Message : "Indefinido."), "Contas não inseridas", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
					if (result == DialogResult.Retry)
						UpdateContas(empresas_id);
				}
			}

			if (toDeleteIds.Count > 0) {
				// Tenta deletar as contas removidas do banco online, mas nem sempre é possível devido ao
				// histórico de ordens. Independentemente disso, essas contas estão desativadas e caso permaneçam
				// no banco será apenas para registro de ordens.
				offline.DeleteFrom("contas", "id IN(" + string.Join(",", toDeleteIds) + ")");
			}

			int ignoreCode = 0;
			for (int i = 0; i < toUpdateIds.Count; i++) {
				UpdateCurrent:
				offline.Update("contas", toUpdateColumns[i].ToArray(), toUpdateValues[i].ToArray(), "id = " + toUpdateIds[i]);
				if (offline.AffectedRows != 1) {
					DialogResult result = DialogResult.Cancel;
					if (ignoreCode == 0) {
						result = MessageBox.Show("Não foi possível atualizar uma das contas da sua empresa.\nErro: " + ((offline.Error != null) ? offline.Error.Message : "Indefinido."), "Conta não atualizada", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
					} else if (ignoreCode != -1) {
						MessageBoxManager.Abort = "Ignorar todos";
						result = MessageBox.Show("Não foi possível atualizar " + (ignoreCode + 1) + " contas da sua empresa.\nErro: " + ((offline.Error != null) ? offline.Error.Message : "Indefinido."), "Conta não atualizada", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
					}

					if (result == DialogResult.Retry)
						goto UpdateCurrent;
					else if (result == DialogResult.Abort)
						ignoreCode = -1;
					else
						ignoreCode++;
				}
			}

			ResetMessageBoxButtons();
		}

		public Login () {
			InitializeComponent();
			ResetMessageBoxButtons();
			loginIntance = this;

			StringCryptography.PasswordHash = passwordHash;
			StringCryptography.SaltKey = saltKey;
			StringCryptography.VIKey = viKey;

			lastSessionPath = Path.Combine(Application.StartupPath, "data.lrv");
			if (File.Exists(lastSessionPath)) {

			}

			Connect();
		}

		private bool close = false;
		private string lastSessionPath;

		private void Connect () {
			//Online:
			online = new MySQLManager("hidroponia_online", "greenhouse", "miVRLKzz666r53Pk");
			if (!online.Connected) {
				DialogResult result = MessageBox.Show("Não foi possível criar a conexão com a nossa base de dados para realizar o login.", "Não conectado", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
				if (result == DialogResult.Retry)
					Connect();
				else
					close = true;
			}

			//Offline:
			ConnectOffline:
			offline = new MySQLManager("hidroponia", offlineUser, offlinePassword);
			if (!offline.Connected) {
				MessageBoxManager.Ignore = "Configurar";
				DialogResult result = MessageBox.Show("Não foi possível criar a conexão com a base de dados local.", "Não conectado", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
				if (result == DialogResult.Retry) {
					goto ConnectOffline;
				} else if (result == DialogResult.Ignore) {
					Form setConnection = new DatabaseConfig(); //Change!
					setConnection.ShowDialog();
					goto ConnectOffline;
				} else {
					close = true;
				}
				ResetMessageBoxButtons();
			}
		}

		private void textbox_Enter (object sender, EventArgs e) {
			TextBox textBox = (TextBox)sender;
			if (textBox.ForeColor == Color.Silver) {
				textBox.Text = "";
				textBox.ForeColor = Color.Black;
			}
		}

		private void textbox_Leave (object sender, EventArgs e) {
			TextBox textBox = (TextBox)sender;
			if (textBox.Text == "") {
				textBox.Text = textBox.Tag.ToString();
				textBox.ForeColor = Color.Silver;
			}
		}

		private void panel1_Click (object sender, EventArgs e) {
			username.Focus();
		}

		private void panel2_Click (object sender, EventArgs e) {
			password.Focus();
		}

		private void sign_in_Click (object sender, EventArgs e) {
			string user = "";
			string pass = "";

			if (username.ForeColor == Color.Black && password.ForeColor == Color.Black) {
				user = username.Text;
				pass = password.Text;
			}

			if (user.Length > 0 && pass.Length > 0) {
				online.Select("SELECT * FROM contas WHERE usuario = '" + user + "' AND senha = MD5('" + pass + "') AND em_uso AND tipo IN ('Administrador', 'Operário')");
				if (online.NumRows == 1) {
					Geral.conta = online.SelectResult[1];

					// Valid account, let's check company's plan
					online.Select("SELECT * FROM planos WHERE empresas_id = " + Geral.conta[1] + " AND CURRENT_DATE() BETWEEN data_inicio AND data_fim");
					if (online.NumRows <= 0) {
						// Deny access
						MessageBox.Show("O plano da empresa está expirado ou não foi encontrado. Por favor, entre em contato com os desenvolvedores deste software para negociar um plano e comprar uma licença.", "Plano expirado ou inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					Geral.plano = online.SelectResult[1];

					// And check the computer MAC
					var macs = (from netInterface in NetworkInterface.GetAllNetworkInterfaces()
								where netInterface.OperationalStatus == OperationalStatus.Up && netInterface.GetPhysicalAddress().ToString() != string.Empty
								select netInterface.GetPhysicalAddress());

					online.Select("SELECT * FROM maquinas WHERE empresas_id = " + Geral.conta[1] + " AND REPLACE(MAC, ':', '') IN ('" + string.Join("', '", macs) + "')");
					if (online.NumRows <= 0) {
						// Deny access
						MessageBox.Show("Computador não licenciado. Entre em contato com o administrador da empresa para cadastrar esse servidor local.", "Computador não autorizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					// Allow access
					online.Select("SELECT * FROM empresas WHERE id = " + Geral.conta[1]);
					offline.Select("SELECT * FROM empresas WHERE id = " + Geral.conta[1]);

					if (online.NumRows == 1) {
						Geral.empresa = online.SelectResult[1];
					} else {
						DatabaseStructureError("Empresa não encontrada");
						return;
					}

					if (offline.NumRows == 1) {
						//Empresa existente
						UpdateEmpresa(online.SelectResult[1], offline.SelectResult[1]);
						UpdateContas(Geral.conta[1]);
					} else {
						//Empresa não existente
						InsertEmpresa:
						offline.InsertInto("empresas", empresaColumns, online.SelectResult, 1);
						if (offline.AffectedRows == 1) {
							UpdateContas(Geral.conta[1]);
						} else {
							DialogResult result = MessageBox.Show("Não foi possível gravar as informações da sua empresa.\nErro: " + ((offline.Error != null) ? offline.Error.Message : "Indefinido."), "Empresa não gravada", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
							if (result == DialogResult.Retry)
								goto InsertEmpresa;
						}
					}

					LoadForm(Forms.Geral);
				} else {
					MessageBox.Show("Usuário e/ou senha incorretos.", "Erro ao entrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else {
				MessageBox.Show("Usuário e/ou senha inválidos.", "Erro ao entrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Login_Load (object sender, EventArgs e) {
			if (close)
				Exit();
		}
	}
}