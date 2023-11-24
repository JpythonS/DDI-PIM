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

        public static bool ExibirModalCancelar()
        {
            DialogResult result = MessageBox.Show("Você realmente deseja cancelar ?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            
            return result == DialogResult.Yes;

        }

        public static bool ExibirModalExclusao()
        {
            DialogResult result = MessageBox.Show(
                "Tem certeza de que deseja excluir?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            return result == DialogResult.Yes;
        }
    }
}
