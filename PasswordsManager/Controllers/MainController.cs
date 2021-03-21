using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordsManager.Models;
using PasswordsManager.Services;
using PasswordsManager.Views;
using System.Security.Cryptography;

namespace PasswordsManager.Controllers
{
    public class MainController
    {
        private DataGridView _dataGridView;
        private PasswordTableService _service;

        private List<string> passwords = new List<string>();

        
        public MainController(DataGridView dataGrid)
        {
            _service = new PasswordTableService(SqlConnectionDataService.ConnectionDataBase());
            _dataGridView = dataGrid;
        }


        public string GetMD5Hash(string text)
        {
            using(var hashAlg = MD5.Create())
            {
                byte[] hash = hashAlg.ComputeHash(Encoding.UTF8.GetBytes(text));
                var builder = new StringBuilder(hash.Length * 2);

                for(int i =0; i<hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("X2"));
                }
                return builder.ToString();
            }
        }
        public void GetData(List<UserData> dataList)
        {
            _dataGridView.Rows.Clear();
            dataList = _service.GetAll();

            foreach(var items in dataList)
            {
                _dataGridView.Rows.Add(items.Login, items.Password, items.Id);
                passwords.Add(items.Password);
            }
        }

        public void MainView_Load(object sender, EventArgs e)
        {
            GetData(_service.GetAll());
        }

        public void addToolStripButton_Click(object sender, EventArgs e)
        {
            var data = new UserData();
            var addDataWindow = new PasswordEditorView(data);

            var res = addDataWindow.ShowDialog();

            if(res == DialogResult.OK)
            {
                ValidationPassword(passwords, data.Password);

                _dataGridView.Rows.Add(data.Login, data.Password);
                _service.Add(data);
                GetData(_service.GetAll());
            }
        }

        public void ValidationPassword(List<string> list,string password)
        {
            for (int i =0; i < list.Count; i++)
            {
               
                if (list[i] != password)
                {
                    list.Add(password);
                }
                    
            }
        }

        public void updateToolStripButton_Click(object sender, EventArgs e)
        {
            GetData(_service.GetAll());
        }

        public void changeDataToolStripButton_Click(object sender, EventArgs e)
        {
            if (_dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выделите полную строку для ее изменения!");
                return;
            }
            
            var selectData = _dataGridView.SelectedRows[0];
            var data = new UserData
            {
                Login = selectData.Cells[0].Value.ToString(),
                Password = selectData.Cells[1].Value.ToString(),
                Id = int.Parse(selectData.Cells[2].Value.ToString())

            };

            var addDataWindow = new PasswordEditorView(data);
            var res = addDataWindow.ShowDialog();

            

            if (res == DialogResult.OK)
            {
                _dataGridView.Rows.Add(data.Login, data.Password);

                _service.ChangeData(data.Id,data);
                GetData(_service.GetAll());
            }
        }

        public void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (_dataGridView.SelectedRows.Count > 0 && _dataGridView.SelectedRows != null)
            {
                var selectData = _dataGridView.SelectedRows[0];
                int id = int.Parse(selectData.Cells[2].Value.ToString());

                
                _service.Delete(id);
                GetData(_service.GetAll());

            }
            else
                MessageBox.Show("Выберите строку для удаления!");
        }

        public void copyToolStripButton_Click(object sender, EventArgs e)
        {   
            var cell = _dataGridView.SelectedCells[0];

            Clipboard.SetText($"{cell.Value}");

            if (_dataGridView.SelectedRows.Count != 0)
            {
                var dataString = _dataGridView.SelectedRows[0];

                Clipboard.SetText($"{dataString.Cells[0].Value}  {dataString.Cells[1].Value}");
            }
        }

        public void exitToolStripButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
