using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook_Group_Manager
{
    public class AuraeColor
    {
        private Color SuccessBackColor = Color.FromArgb(198, 239, 206);
        private Color SuccessForeColor = Color.FromArgb(0, 97, 0);

        private Color DangerBackColor = Color.FromArgb(255, 199, 206);
        private Color DangerForeColor = Color.FromArgb(156, 0, 6);

        private Color WarningBackColor = Color.FromArgb(255, 235, 156);
        private Color WarningForeColor = Color.FromArgb(156, 101, 0);

        private Color InfoBackColor = Color.FromArgb(211, 225, 241);
        private Color InfoForeColor = Color.FromArgb(37, 82, 143);

        public Color AuraeBackColor { get; set; }
        public Color AuraeForeColor { get; set; }
        public AuraeColor(AuraeColorEnum @enum)
        {
            switch (@enum)
            {
                case AuraeColorEnum.Success:
                    AuraeBackColor = SuccessBackColor;
                    AuraeForeColor = SuccessForeColor;
                    break;
                case AuraeColorEnum.Warning:
                    AuraeBackColor = WarningBackColor;
                    AuraeForeColor = WarningForeColor;
                    break;
                case AuraeColorEnum.Danger:
                    AuraeBackColor = DangerBackColor;
                    AuraeForeColor = DangerForeColor;
                    break;
                case AuraeColorEnum.Info:
                    AuraeBackColor = InfoBackColor;
                    AuraeForeColor = InfoForeColor;
                    break;
                default:
                    AuraeBackColor = InfoBackColor;
                    AuraeForeColor = InfoForeColor;
                    break;
            }
        }
    }

    public enum AuraeColorEnum
    {
        Success,
        Warning,
        Danger,
        Info
    }
}
