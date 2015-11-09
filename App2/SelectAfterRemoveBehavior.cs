using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App2
{
    // Behaviors need a reference to Universal Windows > Extensions > behaviors SDK (12.0)

    [TypeConstraint(typeof(ListViewBase))]
    public class SelectAfterRemoveBehavior : DependencyObject, IBehavior
    {
        private ListViewBase _associatedObject;
        private int _index;

        public DependencyObject AssociatedObject
        {
            get { return _associatedObject; }
        }

        public void Attach(DependencyObject associatedObject)
        {
            _associatedObject = (ListViewBase)associatedObject;
            _associatedObject.SelectionChanged += OnSelectionChanged;
            _associatedObject.ContainerContentChanging += OnContainerContentChanging;
        }

        private void OnContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            if (args.InRecycleQueue)
            {
                if (_index > _associatedObject.Items.Count - 1)
                {
                    _index = _associatedObject.Items.Count - 1;
                }
                _associatedObject.SelectedIndex = _index;
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_associatedObject.SelectedIndex > -1)
            {
                _index = _associatedObject.SelectedIndex;
            }
        }

        public void Detach()
        {
            _associatedObject.SelectionChanged -= OnSelectionChanged;
            _associatedObject.ContainerContentChanging -= OnContainerContentChanging;
        }
    }
}
