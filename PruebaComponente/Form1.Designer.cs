
namespace PruebaComponente
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.etiquetaAviso2 = new DI_Tema5_Ejer2.EtiquetaAviso();
            this.etiquetaAviso1 = new DI_Tema5_Ejer2.EtiquetaAviso();
            this.SuspendLayout();
            // 
            // etiquetaAviso2
            // 
            this.etiquetaAviso2.ColorFinal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.etiquetaAviso2.ColorInicio = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.etiquetaAviso2.Degradado = true;
            this.etiquetaAviso2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaAviso2.ImagenMarca = ((System.Drawing.Image)(resources.GetObject("etiquetaAviso2.ImagenMarca")));
            this.etiquetaAviso2.Location = new System.Drawing.Point(12, 30);
            this.etiquetaAviso2.Marca = DI_Tema5_Ejer2.eMarca.Cruz;
            this.etiquetaAviso2.Margin = new System.Windows.Forms.Padding(2);
            this.etiquetaAviso2.Name = "etiquetaAviso2";
            this.etiquetaAviso2.Size = new System.Drawing.Size(230, 37);
            this.etiquetaAviso2.TabIndex = 1;
            this.etiquetaAviso2.Text = "etiquetaAviso2";
            this.etiquetaAviso2.ClickEnMarca += new System.EventHandler(this.etiquetaAviso2_ClickEnMarca);
            // 
            // etiquetaAviso1
            // 
            this.etiquetaAviso1.ColorFinal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.etiquetaAviso1.ColorInicio = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.etiquetaAviso1.Degradado = false;
            this.etiquetaAviso1.ImagenMarca = ((System.Drawing.Image)(resources.GetObject("etiquetaAviso1.ImagenMarca")));
            this.etiquetaAviso1.Location = new System.Drawing.Point(-123, 67);
            this.etiquetaAviso1.Marca = DI_Tema5_Ejer2.eMarca.Imagen;
            this.etiquetaAviso1.Margin = new System.Windows.Forms.Padding(2);
            this.etiquetaAviso1.Name = "etiquetaAviso1";
            this.etiquetaAviso1.Size = new System.Drawing.Size(65, 9);
            this.etiquetaAviso1.TabIndex = 0;
            this.etiquetaAviso1.Text = "etiquetaAviso1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 9F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 221);
            this.Controls.Add(this.etiquetaAviso2);
            this.Controls.Add(this.etiquetaAviso1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "hola";
            this.ResumeLayout(false);

        }

        #endregion

        private DI_Tema5_Ejer2.EtiquetaAviso etiquetaAviso1;
        private DI_Tema5_Ejer2.EtiquetaAviso etiquetaAviso2;
    }
}

