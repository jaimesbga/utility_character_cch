using System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Controles
{
    class cuadricula
    {

        private Button[,] panel;
        
        private int _x, _y;

        public cuadricula(int _X, int _Y) {

            _x = _X;
            _y = _Y;

            panel = new Button[_y, _x];

            for (int i = 0; i < _y; i++)
            {
                for (int j = 0; j < _x; j++)
                {

                    panel[i, j] = new Button();
                    panel[i, j].Width = 20;
                    panel[i, j].Height = 20;
                    panel[i, j].FlatStyle = FlatStyle.Flat;
                    panel[i, j].BackColor = System.Drawing.SystemColors.ControlLightLight;
                    panel[i, j].ForeColor = System.Drawing.Color.White;
                    panel[i, j].Text = "";
                    panel[i, j].TabIndex = i * j;
                    panel[i, j].Location = new System.Drawing.Point(
                    panel[i, j].Width * j, panel[i, j].Height * i);
                    


                    if (i >= 0 && i <= 3)
                    {
                        panel[i, j].Enabled = false;
                        panel[i, j].BackColor = System.Drawing.SystemColors.ButtonFace;
                    }

                    panel[i, j].MouseHover += new EventHandler((Sender, e) =>
                    {
                        //Manejo de Evento de Botones 
                        Button sButton = (Button)Sender;

                        if (sButton.BackColor == System.Drawing.SystemColors.ControlLightLight)
                        {
                            sButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                        }
                        else
                        {
                            sButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
                        }
                    });
                    

                }// fin for interno
            } //fin for externo      
        

        }// constructor

        public Button get_button(int _X, int _Y) {

            return panel[_X, _Y];
           
        }


        public bool setCaracter(string strIn) {


            string[] strSplit = strIn.Split(',');            
            Int16 sBits = 0;
            int cStr = 0;
            Int16 strMask = 0;
            
            if (strSplit.Length < 1) return false; 

            for(int i=0 ; i<_x ; i++)// Recorrido de Columnas....
            {
            
                sBits = strToHex(strSplit[cStr]);

                sBits = (Int16)(sBits << 8);

                sBits += strToHex(strSplit[cStr+1]);

                for(int j =(_y-1); j >= 0; j--) //Recorrido de filas desde abajo.
                {
                    

                    strMask = (Int16) Math.Pow(2.0,j);

                    if ((sBits & strMask) != 0)
                    {

                        panel[j, i].BackColor = System.Drawing.SystemColors.ControlDarkDark;

                    }
                    else                   
                    {

                        panel[j, i].BackColor = System.Drawing.SystemColors.ControlLightLight;
                    
                    }

                }
            
                cStr +=2;
            }

           
            return true;
        
        }

        public string procesarCuadriculas() {

            double cCont8 = 15;
            int nHex = 0;
            double iBit = 0;
            string resul = "";

            for (int i = 0; i < _x; i++)
            {
                for (int j = (_y-1); j >= 0; j--)
                {

                    if (cCont8 == -1)
                    {
                        cCont8 = 7;

                        resul += "0x"+HexToSring (nHex)+ ",";
                        nHex = 0;
                    }

                    if (panel[j, i].BackColor == System.Drawing.SystemColors.ControlDarkDark)
                    {
                        iBit = 1;               
                    }
                    else 
                    {
                        iBit = 0;
                    }


                    nHex += (int)(iBit * (Math.Pow(2,cCont8)));

                    cCont8--;

                }



            }

            resul += "0x" + HexToSring(nHex);

            return resul;
        }

        public void limpiarPanel()
        {

            for (int i = 0; i < _x;i++ )
            {
                for (int j = 0; j < _y; j++)
                {  

                    panel[j, i].BackColor = System.Drawing.SystemColors.ControlLightLight;

                }

            }

        }

        public int get_X(){
            return _x;
        }
        public int get_Y()
        {
            return _y;

        }

        private string HexToSring(int _sho)
        {
            string resul = "";
            int aux = _sho;

            resul += getStringHex(((_sho >> 4) & 0x0F));
            resul += getStringHex(((_sho >> 0) & 0x0F));
         

            return resul;

        }


        private byte strToHex(string _str) {

            byte resul = 0;
            char[] cValor;

            // para fomato 0x00 hexadecimal...!!!

            if (_str.Length != 4) return 0;

            cValor = _str.ToCharArray();

            resul = get_strToHex(cValor[2]);

            resul = (byte)(resul << 4);

            resul |= get_strToHex(cValor[3]); 

            return resul;
        }


        private byte get_strToHex(char _c) 
        {
            switch (_c)
            {

                case '0': return 0;
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                case 'A': return 10;
                case 'B': return 11;
                case 'C': return 12;
                case 'D': return 13;
                case 'E': return 14;
                case 'F': return 15;
                default: return 0;
            }
        
        }
        private string getStringHex(int _c)
        {


            switch (_c)
            {

                case 0: return "0";
                case 1: return "1";
                case 2: return "2";
                case 3: return "3";
                case 4: return "4";
                case 5: return "5";
                case 6: return "6";
                case 7: return "7";
                case 8: return "8";
                case 9: return "9";
                case 10: return "A";
                case 11: return "B";
                case 12: return "C";
                case 13: return "D";
                case 14: return "E";
                case 15: return "F";


            }

            return null;

        }
    }
}
