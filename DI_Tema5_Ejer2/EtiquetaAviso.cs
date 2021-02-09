using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI_Tema5_Ejer2
{
    public enum eMarca
    {
        Nada,
        Cruz,
        Circulo
    }

    public partial class EtiquetaAviso : Control
    {
        //cibermedium by Kent Nassen
        /*
        ____ ____ _  _ ____ ___ ____ _  _ ____ ___ ____ ____ 
        |    |  | |\ | [__   |  |__/ |  | |     |  |  | |__/ 
        |___ |__| | \| ___]  |  |  \ |__| |___  |  |__| |  \*/

        public EtiquetaAviso()
        {
            InitializeComponent();
        }

        /*
        ___  ____ ____ ___  _ ____ ___  ____ ___  ____ ____ 
        |__] |__/ |  | |__] | |___ |  \ |__| |  \ |___ [__  
        |    |  \ |__| |    | |___ |__/ |  | |__/ |___ ___]
       */

        //Marca==================================================

        private eMarca marca = eMarca.Nada;
        [Category("Apariencia")]
        [Description("Coloca una x o un circulo, o nada")]
        public eMarca Marca
        {
            set
            {
                marca = value;
                this.Refresh();
                // Lanzamos el Refresh para que se vuelva a pintar el componente al cambiar la marca.
            }
            get { return marca; }
        }

        //*********FONDO DEGRADADO*********************

        //Degradado boleana
        private bool degradado = false;
        [Category("Apariencia")]
        [Description("Le pone de fondo un degradado")]
        public bool Degradado
        {
            set
            {
                degradado = value;
                this.Refresh(); //REFRESCAR LOS GRÁFICOS
            }
            get
            {
                return degradado;
            }
        }

        //Colores
        private Color colorInicio;
        [Category("Apariencia")]
        [Description("Color de inicio para el fondo de degradado")]
        public Color ColorInicio
        {
            set
            {
                colorInicio = value;
                this.Refresh();
            }
            get
            {
                return colorInicio;
            }
        }

        private Color colorFinal;
        [Category("Apariencia")]
        [Description("Color de inicio para el fondo de degradado")]
        public Color ColorFinal
        {
            set
            {
                colorFinal = value;
                this.Refresh();
            }
            get
            {
                return colorFinal;
            }
        }

        /*
         * 
        ____ _  _ ____ _  _ ___ ____ ____    ____ _  _ 
        |___ |  | |___ |\ |  |  |  | [__     |  | |\ | 
        |___  \/  |___ | \|  |  |__| ___]    |__| | \|
         */
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            int grosor = 0; //Grosor de las líneas de dibujo
            int offsetX = 0; //Desplazamiento a la derecha del texto
            int offsetY = 0; //Desplazamiento hacia abajo del texto
                             //Esta propiedad provoca mejoras en la apariencia o en la eficiencia
                             // a la hora de dibujar
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //Dependiendo del valor de la propiedad marca dibujamos una

            //Degradado
            if (degradado)
            {
                LinearGradientBrush gradientColor = new LinearGradientBrush(
                    new PointF(0, 0),
                    new PointF(this.Width, this.Height),
                    colorInicio,
                    colorFinal);
            }

            //Cruz o un Círculo
            switch (Marca)
            {
                case eMarca.Circulo:
                    grosor = 20;
                    g.DrawEllipse(new Pen(Color.Green, grosor), grosor, grosor,

                    this.Font.Height, this.Font.Height);

                    offsetX = this.Font.Height + grosor;
                    offsetY = grosor;
                    break;
                case eMarca.Cruz:
                    grosor = 5;
                    Pen lapiz = new Pen(Color.Red, grosor);
                    g.DrawLine(lapiz, grosor, grosor, this.Font.Height,
                    this.Font.Height);
                    g.DrawLine(lapiz, this.Font.Height, grosor, grosor,
                    this.Font.Height);
                    offsetX = this.Font.Height + grosor;
                    offsetY = grosor / 2;
                    //Es recomendable liberar recursos de dibujo pues se

                    //pueden realizar muchos y cogen memoria

                    lapiz.Dispose();
                    break;
            }

            //Finalmente pintamos el Texto; desplazado si fuera necesario
            SolidBrush b = new SolidBrush(this.ForeColor);
            g.DrawString(this.Text, this.Font, b, offsetX + grosor, offsetY);
            Size tam = g.MeasureString(this.Text, this.Font).ToSize();
            this.Size = new Size(tam.Width + offsetX + grosor, tam.Height + offsetY* 2);

            

           
            
            
            b.Dispose();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Refresh(); //cada vez que cambiamos el texto refrescamos los gráficos
        }
    }
}
