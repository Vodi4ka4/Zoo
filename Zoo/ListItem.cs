using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoo
{
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();
        }
        #region Properties
        private string _description;
        private string _name_product;
        private string _coust;
        private string _manufacturer;
        private Image _icon;
        private string _id;

        [Category("Custom Props")]
        public string Id
        {
            get { return _id; }
            set { _id = value;}
        }

        [Category("Custom Props")]
        public string Description
        {
            get { return _description; }
            set { _description = value; label_description.Text = value; }
        }

        [Category("Custom Props")]
        public string Name_product
        {
            get { return _name_product; }
            set { _name_product = value; label_name_product.Text = value; }
        }

        [Category("Custom Props")]
        public string Coust
        {
            get { return _coust; }
            set { _coust = value; label_coust_number.Text = value; }
        }
        [Category("Custom Props")]
        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; label_manufacturer.Text = value; }
        }

        [Category("Custom Props")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictureBox_product.Image = value; }
        }
        #endregion
    }
}
