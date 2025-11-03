using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private BancoDePreguntas _preguntas;
        private Pregunta _preguntaActual;

        public string TextoDeLaPregunta
        {
            get => _textoDeLaPregunta;
            set
            {
                if (_textoDeLaPregunta != value)
                {
                    _textoDeLaPregunta = value;
                    OnPropertyChanged(nameof(TextoDeLaPregunta));
                }
            }
        }

        public string TextoDelResultado
        {
            get => _TextoDelResultado;
            set
            {
                if (_TextoDelResultado != value)
                {
                    _TextoDelResultado = value;
                    OnPropertyChanged(nameof(TextoDelResultado));
                }
            }
        }

        private string _textoDeLaPregunta;
        private string _TextoDelResultado;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand PreguntaAnteriorCommand { private set; get; }
        public ICommand PreguntaSiguienteCommand { private set; get; }
        public ICommand CiertoCommand { private set; get; }
        public ICommand FalsoCommand { private set; get; }
        public MainViewModel()
        {
            _preguntas = new BancoDePreguntas();
            _preguntaActual = _preguntas.GetPrimeraPregunta();
            TextoDeLaPregunta = _preguntaActual.Texto;
            TextoDelResultado = string.Empty;
            PreguntaAnteriorCommand = new Command(IrAPreguntaAnterior);
            PreguntaSiguienteCommand = new Command(IrAPreguntaSiguiente);
            CiertoCommand = new Command<bool>(VerificarRespuesta);
            FalsoCommand = new Command<bool>(VerificarRespuesta);
        }

        public void IrAPreguntaSiguiente()
        {
            _preguntaActual = _preguntas.GetSiguientePregunta();
            TextoDeLaPregunta = _preguntaActual.Texto;
            TextoDelResultado = string.Empty;

        }

        public void IrAPreguntaAnterior()
        {
            _preguntaActual = _preguntas.GetPreguntaAnterior();
            TextoDeLaPregunta = _preguntaActual.Texto;
            TextoDelResultado = string.Empty;
        }

        public void VerificarRespuesta(bool RespuestaDelUsuario)
        {
            if (RespuestaDelUsuario == _preguntaActual.RespuestaEsCierto)
            {
                TextoDelResultado = "¡Correcto!";
            }
            else
            {
                TextoDelResultado = "¡Incorrecto!";
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
