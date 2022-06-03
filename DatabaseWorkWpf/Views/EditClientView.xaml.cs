using DatabaseWorkWpf.ViewModels;

namespace DatabaseWorkWpf.Views;

public partial class EditClientView
{
    public EditClientView(EditClientViewModel viewModel)
    {
        DataContext = viewModel;
        viewModel.Closed += (_, _) => Close();
        InitializeComponent();
    }
    
}