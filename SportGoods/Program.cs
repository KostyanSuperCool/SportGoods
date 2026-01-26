namespace SportGoods
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            bool exitProgram = false;

            while (!exitProgram)
            {
                using(var formlogin = new FormLogin())
                {
                    if(formlogin.ShowDialog() == DialogResult.OK)
                    {
                        using(var formProducts = new FormProducts(
                            formlogin.CurrentUser,
                            formlogin.IsGuest))
                        {
                            if(formProducts.ShowDialog() == DialogResult.Cancel)
                            {
                                continue;
                            }
                            else
                            {
                                exitProgram = true;
                            }
                        }
                    }
                    else
                    {
                        exitProgram = true;
                    }
                }
            }
        }
    }
}