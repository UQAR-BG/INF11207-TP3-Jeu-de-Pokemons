using System;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class RelayCommandWithParam<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public RelayCommandWithParam(Action<T> execute)
        {
            _execute = execute;
        }

        public RelayCommandWithParam(Predicate<T> canExecute, Action<T> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parametre)
        {
            return _canExecute == null || _canExecute((T)parametre);
        }

        public void Execute(object parametre)
        {
            if (_execute != null)
            {
                _execute((T)parametre);
            }
        }
    }
}
