using System;
using System.Drawing;

namespace CS_20200408
{
    public class Draw
    {
        Menu myMenu = new Menu();
        public void saveImage(string path, Bitmap image){
            image.Save(path);
        }

        public void drawContorno(Bitmap image, int altezza, int larghezza,int partenza,int partenzay){
            for(int i=partenzay; i<partenzay+altezza; i++){
                for(int k=partenza;k<partenza+larghezza;k++)
                {
                    if(i==partenzay || i==partenzay+altezza-1){
                        image.SetPixel(k,i,Color.Black);
                    }else
                    {
                        image.SetPixel(partenza,i,Color.Black);
                        image.SetPixel(partenza+larghezza-1,i,Color.Black);
                    }
                }
            }
        }

        public void drawRectangle(Bitmap image, int altezza, int larghezza, int partenza){
            for(int i=0; i<altezza; i++){
                for(int k=partenza;k<partenza+larghezza;k++)
                {
                    image.SetPixel(k,i,Color.Black);
                }
            }
        }

        public void drawFigureRectangle(Bitmap image, int partenza, int baser, int altezza){
            
            using (Graphics graphics = Graphics.FromImage(image))
            {
                using (System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black))
                {
                    graphics.FillRectangle(myBrush, new Rectangle(partenza, 0, baser, altezza));
                }
            }             
        }

        public void drawFigureSquare(Bitmap image, int partenza, int lato){
             using (Graphics graphics = Graphics.FromImage(image))
            {
                using (System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black))
                {
                    graphics.FillRectangle(myBrush, new Rectangle(partenza, 0, lato, lato));
                }
            }  
        }

        public void drawFigureCircle(Bitmap image, int partenza, int raggio){
             using (Graphics graphics = Graphics.FromImage(image))
            {
                using (System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black))
                {
                    graphics.FillEllipse(myBrush, new Rectangle(partenza, 0, raggio, raggio));
                }
            }  
        }
    }
}