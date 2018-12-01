using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INF518Core.Clases
{
    public class MenuPrincipal
    {
        MenuStrip menu;
        public MenuPrincipal(MenuStrip menu)
        {
            this.menu = menu;
        }
        /// <summary>
        /// Actualiza las opciones del menu principal del sistema
        /// </summary>
        /// <param name="permisos">
        /// El listado de permisos separados por ; Ejemplo: 100;200;300;
        /// </param>
        public void UpdateMenuItems(string permisos)
        {
            this.UpdateDropDownItems(this.menu.Items, permisos);
        }
        /// <summary>
        /// Actualiza los sub menu
        /// </summary>
        /// <param name="permisos">
        /// Indica un string de permisos a usarse para el menu principal
        /// </param>
        private void UpdateDropDownItems(ToolStripItemCollection items, string permisos)
        {
            foreach (ToolStripItem item in items)
            {
                if (item.Tag != null)
                {
                    string key = ";" + item.Tag.ToString() + ";";
                    switch (key)
                    {
                        case ";100;":
                            item.Enabled = true;
                            break;
                        case ";200;":
                            item.Enabled = true; //Desactivando a conectarse.
                            break;
                        case ";300;":
                            item.Enabled = true; //Desactivando a conectarse.
                            break;
                        default:
                            //-
                            // Para desactivar/activar los otros items
                            //--------------------------------------------------
                            if (permisos.IndexOf(key) < 0)
                            {
                                item.Enabled = false;
                                //item.Visible = false;
                            }
                            if (permisos.IndexOf(key) >= 0 || item.Tag.ToString().Trim().Length == 0)
                            {
                                item.Enabled = true;
                                //item.Visible = true;
                            }
                            break;
                    }
                    ToolStripMenuItem mnu = new ToolStripMenuItem();
                    try
                    {
                        mnu = (ToolStripMenuItem)item;
                    }
                    catch { }
                    finally
                    {
                        if (mnu.HasDropDownItems && mnu.Enabled)
                            UpdateDropDownItems(mnu.DropDownItems, permisos);
                    }
                }

            }
        }

    }
}
