using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVApp
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        QLSVEntities context = new QLSVEntities();
        SinhVien sinhVienDuocChon;
        private void Thembttn_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien()
            {
                SV_Name = txtName.Text,
                SV_Phone = txtPhone.Text,
                SV_Email = txtEmail.Text
            };
            context.SinhViens.Add(sv);
            context.SaveChanges();
            MessageBox.Show("Thêm sinh viên thành công!");
            HienThiDanhSachSinhVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //int svId = int.Parse(txtId.Text); // Giả sử có một TextBox để nhập ID
            //SinhVien sv = context.SinhViens.FirstOrDefault(s => s.SV_ID == svId);
            //if (sv != null)
            //{
            //    context.SinhViens.Remove(sv);
            //    context.SaveChanges();
            //    MessageBox.Show("Xóa sinh viên thành công!");
            //    HienThiDanhSachSinhVien();
            //}
            //else
            //{
            //    MessageBox.Show("Sinh viên không tồn tại!");
            //}
            if (sinhVienDuocChon != null)
            {
                context.SinhViens.Remove(sinhVienDuocChon);
                context.SaveChanges();
                HienThiDanhSachSinhVien(); // Làm mới DataGridView
                MessageBox.Show("Xóa sinh viên thành công!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //int svId = int.Parse(txtId.Text); // Giả sử có một TextBox để nhập ID
            //SinhVien sv = context.SinhViens.FirstOrDefault(s => s.SV_ID == svId);
            //if (sv != null)
            //{
            //    sv.SV_Name = txtName.Text;
            //    sv.SV_Phone = txtPhone.Text;
            //    sv.SV_Email = txtEmail.Text;
            //    context.SaveChanges();
            //    MessageBox.Show("Cập nhật thông tin sinh viên thành công!");
            //    HienThiDanhSachSinhVien();
            //}
            //else
            //{
            //    MessageBox.Show("Sinh viên không tồn tại!");
            //}
            if (sinhVienDuocChon != null)
            {
                sinhVienDuocChon.SV_Name = txtName.Text;
                sinhVienDuocChon.SV_Phone = txtPhone.Text;
                sinhVienDuocChon.SV_Email = txtEmail.Text;
                context.SaveChanges();
                HienThiDanhSachSinhVien(); // Làm mới DataGridView
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form hiện tại
        }
        private void HienThiDanhSachSinhVien()
        {
            var danhSachSinhVien = context.SinhViens.ToList();
            dataGridView1.DataSource = danhSachSinhVien;
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDanhSachSinhVien();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int svId = (int)dataGridView1.Rows[index].Cells["SV_ID"].Value;
                sinhVienDuocChon = context.SinhViens.FirstOrDefault(s => s.SV_ID == svId);
                // Đặt giá trị cho các TextBox từ sinhVienDuocChon
                txtName.Text = sinhVienDuocChon.SV_Name;
                txtPhone.Text = sinhVienDuocChon.SV_Phone;
                txtEmail.Text = sinhVienDuocChon.SV_Email;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.ToLower();
            var ketQuaTimKiem = context.SinhViens.Where(s => s.SV_Name.ToLower().Contains(searchTerm)
                                                || s.SV_Phone.Contains(searchTerm)
                                                || s.SV_Email.ToLower().Contains(searchTerm)).ToList();
            dataGridView1.DataSource = ketQuaTimKiem;
        }
    }
}
