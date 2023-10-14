using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDI
{
    public class ModalService
    {
        public static bool ExibirModalSairSistema()
        {
            DialogResult result = MessageBox.Show(
                "Tem certeza de que deseja sair?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            return result == DialogResult.Yes;
        }
    }
}
