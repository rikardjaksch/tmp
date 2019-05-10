namespace wpf_windsor.Views
{
    public interface IViewFactory
    {
        T CreateView<T>() where T : IView;
    }
}
