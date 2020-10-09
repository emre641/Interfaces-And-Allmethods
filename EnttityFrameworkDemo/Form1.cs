using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnttityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();          /// burada new ledik
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();  //tabloya veriyi gönderdik
        }

        private void SearchProducts(string key)             //tabloya veriyi gönderdik
        {
            // var result = _productDal.GetAll().Where(p=> p.Name.ToLower().Contains(key.ToLower)).ToList();
            var result = _productDal.GetByName(key);
            dgwProducts.DataSource = result;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product 
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitePrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            });

            LoadProducts();

            MessageBox.Show("Added!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitePriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStocAmountUpdate.Text)
            });

            LoadProducts();

            MessageBox.Show("Updated!");
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitePriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStocAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product 
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)         //Silmek için Id yeterlidir.
                
            });

            LoadProducts();

            MessageBox.Show("Deleted!");
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(txbSearch.Text);
            
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            _productDal.GetById(1);    
        }
    }
}
