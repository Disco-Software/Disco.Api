using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Disco.Mobile.Renderers
{
    /// <summary>
    /// Этот класс описывает костумизацию контролера TabbedPage
    /// </summary>
    public class CustomTabbedPage : TabbedPage
    {
        /// <summary>
        /// Розмер контролера
        /// </summary>
        public static readonly BindableProperty SizeProperty =
        BindableProperty.Create("Size", typeof(double), typeof(CustomTabbedPage), 0.0,
        defaultValueCreator: bindable => Device.GetNamedSize(NamedSize.Large, (Label)bindable));

        /// <summary>
        /// Событие которое отслеживает клик по центровой кнопке
        /// </summary>
        public event EventHandler CenterButtonClicked;

        /// <summary>
        /// Метод который выполняет роль потставного метода для события CenterButtonClicked
        /// </summary>
        public void SendCenterButtonClicked()
        {
            EventHandler eventHandler = this.CenterButtonClicked;
            eventHandler?.Invoke((object)this, EventArgs.Empty);
        }

        /// <summary>
        /// Свойство которое команду
        /// </summary>
        public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(CustomTabbedPage), null);
        
        /// <summary>
        /// Свойство которое описывает реализацию комманды
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
    }
}