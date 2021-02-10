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
        Circulo,
        Imagen
    }


    public partial class EtiquetaAviso : Control
    {

        private int y;
        private int x;
        private int width;
        private int height;

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

        //*****************MARCA*********************

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

        //*************FONDO DEGRADADO******************

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

        //*****************IMAGEN*********************
        private Image imagenMarca;
        [Category("Apariencia")]
        [Description("Imagen para añadir al componente, cuando Marca está en imagen")]
        public Image ImagenMarca
        {
            set
            {
                imagenMarca = value;
                this.Refresh();
            }
            get
            {
                return imagenMarca;
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
            

            //Degradado
            if (degradado)
            {
                LinearGradientBrush gradientColor = new LinearGradientBrush(
                    new PointF(0, 0),
                    new PointF(this.Width, this.Height),
                    colorInicio,
                    colorFinal);

                g.FillRectangle(gradientColor, new RectangleF(
                    0,0,
                    this.Width, this.Height)); //¿Cómo poner más grande el recuadro??
                //https://docs.microsoft.com/es-es/dotnet/api/system.drawing.drawing2d.lineargradientbrush?view=dotnet-plat-ext-5.0
            }

            //Dependiendo del valor de la propiedad marca dibujamos una
            //Cruz o un Círculo
            switch (Marca)
            {
                case eMarca.Circulo:
                    grosor = 5;
                    g.DrawEllipse(new Pen(Color.Green, grosor), grosor, grosor,

                    this.Font.Height, this.Font.Height);

                    offsetX = this.Font.Height + grosor;
                    offsetY = grosor;

                    x = grosor;
                    y = grosor;
                    width = this.Font.Height;
                    height = this.Font.Height;

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

                    x = grosor;
                    y = grosor;
                    width = this.Font.Height;
                    height = this.Font.Height;
                    //Es recomendable liberar recursos de dibujo pues se

                    //pueden realizar muchos y cogen memoria

                    lapiz.Dispose();
                    break;
                case eMarca.Imagen:
                    if (imagenMarca != null)
                    {
                        grosor = 10;
                        int altoImagen = this.Font.Height;
                        int anchoImagen = (imagenMarca.Width * this.Font.Height) / imagenMarca.Height;
                        g.DrawImage(imagenMarca, grosor, grosor, anchoImagen, altoImagen);//x,y,ancho,alto
                        offsetX = anchoImagen + grosor;
                        offsetY = grosor;

                        x = grosor;
                        y = grosor;
                        width = anchoImagen;
                        height = altoImagen;
                    }
                    break;
            }

            //Finalmente pintamos el Texto; desplazado si fuera necesario
            SolidBrush b = new SolidBrush(this.ForeColor);
            g.DrawString(this.Text, this.Font, b, offsetX + grosor, offsetY); //si pongo por dos la imagen, debo recolocar donde colocamos el texto con referencia a la imagen
            Size tam = g.MeasureString(this.Text, this.Font).ToSize();
            this.Size = new Size(tam.Width + offsetX + grosor, tam.Height + offsetY * 2);
       
            b.Dispose();
        }

        
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Refresh(); //cada vez que cambiamos el texto refrescamos los gráficos
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if(e.X >= this.x && e.X <= this.x+width && e.Y >= this.y && e.Y <= height)
            {
                ClickEnMarca?.Invoke(this,EventArgs.Empty);
            }
        }

        /**
          _      __    _     ____   __    ___       ____  _      ____  _     _____  ___  
         | |    / /\  | |\ |  / /  / /\  | |_)     | |_  \ \  / | |_  | |\ |  | |  / / \ 
         |_|__ /_/--\ |_| \| /_/_ /_/--\ |_| \     |_|__  \_\/  |_|__ |_| \|  |_|  \_\_/
        */

        [Category("Click en marca")]
        [Description("Se lanza cuando se hace click en marca")]
        public event System.EventHandler ClickEnMarca;

    }
}
