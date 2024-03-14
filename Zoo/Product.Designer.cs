namespace Zoo
{
    partial class Product
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button_order = new System.Windows.Forms.Button();
            this.label_login = new System.Windows.Forms.Label();
            this.flowLayoutPanel_Pagination = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel_Product = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBox_Sorting = new System.Windows.Forms.ComboBox();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_list_order = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(17, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Введите для поиска";
            // 
            // button_order
            // 
            this.button_order.Location = new System.Drawing.Point(708, 21);
            this.button_order.Name = "button_order";
            this.button_order.Size = new System.Drawing.Size(75, 23);
            this.button_order.TabIndex = 12;
            this.button_order.Text = "Корзина";
            this.button_order.UseVisualStyleBackColor = true;
            this.button_order.Visible = false;
            this.button_order.Click += new System.EventHandler(this.button_order_Click);
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_login.ForeColor = System.Drawing.Color.Gold;
            this.label_login.Location = new System.Drawing.Point(749, 22);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(0, 15);
            this.label_login.TabIndex = 18;
            // 
            // flowLayoutPanel_Pagination
            // 
            this.flowLayoutPanel_Pagination.Location = new System.Drawing.Point(625, 449);
            this.flowLayoutPanel_Pagination.Name = "flowLayoutPanel_Pagination";
            this.flowLayoutPanel_Pagination.Size = new System.Drawing.Size(158, 31);
            this.flowLayoutPanel_Pagination.TabIndex = 13;
            // 
            // flowLayoutPanel_Product
            // 
            this.flowLayoutPanel_Product.AutoScroll = true;
            this.flowLayoutPanel_Product.Location = new System.Drawing.Point(17, 49);
            this.flowLayoutPanel_Product.Name = "flowLayoutPanel_Product";
            this.flowLayoutPanel_Product.Size = new System.Drawing.Size(766, 394);
            this.flowLayoutPanel_Product.TabIndex = 17;
            // 
            // comboBox_Sorting
            // 
            this.comboBox_Sorting.FormattingEnabled = true;
            this.comboBox_Sorting.Items.AddRange(new object[] {
            "Без сортировки",
            "По возрастанию цены",
            "По убыванию цены",
            "По названию от а до я",
            "По названию от я до а"});
            this.comboBox_Sorting.Location = new System.Drawing.Point(403, 22);
            this.comboBox_Sorting.Name = "comboBox_Sorting";
            this.comboBox_Sorting.Size = new System.Drawing.Size(175, 21);
            this.comboBox_Sorting.TabIndex = 15;
            this.comboBox_Sorting.Text = "Сортировка";
            this.comboBox_Sorting.SelectedIndexChanged += new System.EventHandler(this.comboBox_Sorting_SelectedIndexChanged);
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(17, 23);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(380, 20);
            this.textBox_search.TabIndex = 14;
            this.textBox_search.TextChanged += new System.EventHandler(this.textBox_search_TextChanged);
            // 
            // button_list_order
            // 
            this.button_list_order.Location = new System.Drawing.Point(600, 22);
            this.button_list_order.Name = "button_list_order";
            this.button_list_order.Size = new System.Drawing.Size(100, 23);
            this.button_list_order.TabIndex = 20;
            this.button_list_order.Text = "Список заказов";
            this.button_list_order.UseVisualStyleBackColor = true;
            this.button_list_order.Visible = false;
            this.button_list_order.Click += new System.EventHandler(this.button_list_order_Click);
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 487);
            this.Controls.Add(this.button_list_order);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_order);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.flowLayoutPanel_Pagination);
            this.Controls.Add(this.flowLayoutPanel_Product);
            this.Controls.Add(this.comboBox_Sorting);
            this.Controls.Add(this.textBox_search);
            this.Name = "Product";
            this.Text = "Product";
            this.Load += new System.EventHandler(this.Product_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_order;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Pagination;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Product;
        private System.Windows.Forms.ComboBox comboBox_Sorting;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_list_order;
    }
}