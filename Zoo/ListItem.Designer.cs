namespace Zoo
{
    partial class ListItem
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListItem));
            this.label_coust_number = new System.Windows.Forms.Label();
            this.label_coust = new System.Windows.Forms.Label();
            this.label_name_product = new System.Windows.Forms.Label();
            this.pictureBox_product = new System.Windows.Forms.PictureBox();
            this.label_description = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_manufacturer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_product)).BeginInit();
            this.SuspendLayout();
            // 
            // label_coust_number
            // 
            this.label_coust_number.AutoSize = true;
            this.label_coust_number.Location = new System.Drawing.Point(655, 50);
            this.label_coust_number.Name = "label_coust_number";
            this.label_coust_number.Size = new System.Drawing.Size(13, 13);
            this.label_coust_number.TabIndex = 14;
            this.label_coust_number.Text = "0";
            // 
            // label_coust
            // 
            this.label_coust.AutoSize = true;
            this.label_coust.Location = new System.Drawing.Point(634, 28);
            this.label_coust.Name = "label_coust";
            this.label_coust.Size = new System.Drawing.Size(62, 13);
            this.label_coust.TabIndex = 13;
            this.label_coust.Text = "Стоимость";
            // 
            // label_name_product
            // 
            this.label_name_product.AutoSize = true;
            this.label_name_product.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name_product.Location = new System.Drawing.Point(128, 17);
            this.label_name_product.Name = "label_name_product";
            this.label_name_product.Size = new System.Drawing.Size(232, 24);
            this.label_name_product.TabIndex = 12;
            this.label_name_product.Text = "Наименование продукта";
            // 
            // pictureBox_product
            // 
            this.pictureBox_product.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_product.Image")));
            this.pictureBox_product.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_product.Name = "pictureBox_product";
            this.pictureBox_product.Size = new System.Drawing.Size(100, 83);
            this.pictureBox_product.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_product.TabIndex = 10;
            this.pictureBox_product.TabStop = false;
            // 
            // label_description
            // 
            this.label_description.AutoSize = true;
            this.label_description.Location = new System.Drawing.Point(129, 50);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(55, 13);
            this.label_description.TabIndex = 15;
            this.label_description.Text = "описание";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(453, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Производитель";
            // 
            // label_manufacturer
            // 
            this.label_manufacturer.AutoSize = true;
            this.label_manufacturer.Location = new System.Drawing.Point(469, 50);
            this.label_manufacturer.Name = "label_manufacturer";
            this.label_manufacturer.Size = new System.Drawing.Size(35, 13);
            this.label_manufacturer.TabIndex = 17;
            this.label_manufacturer.Text = "label3";
            // 
            // ListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.label_manufacturer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.label_coust_number);
            this.Controls.Add(this.label_coust);
            this.Controls.Add(this.label_name_product);
            this.Controls.Add(this.pictureBox_product);
            this.Name = "ListItem";
            this.Size = new System.Drawing.Size(770, 103);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_product)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_coust_number;
        private System.Windows.Forms.Label label_coust;
        private System.Windows.Forms.Label label_name_product;
        private System.Windows.Forms.PictureBox pictureBox_product;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_manufacturer;
    }
}
