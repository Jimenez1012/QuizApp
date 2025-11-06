using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuizApp.Models;

namespace QuizApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

    private BancoDePreguntas _preguntas;
    private Pregunta _preguntaActual;


    [ObservableProperty]
    private string? _textoDeLaPregunta;
    [ObservableProperty]
    private string? _TextoDelResultado;
     
        public MainViewModel()
        {
            _preguntas = new BancoDePreguntas();
            _preguntaActual = _preguntas.GetPrimeraPregunta();
            TextoDeLaPregunta = _preguntaActual.Texto;
            TextoDelResultado = string.Empty;           
        }

        [RelayCommand]
        public void IrAPreguntaSiguiente()
        {
            _preguntaActual = _preguntas.GetSiguientePregunta();
            TextoDeLaPregunta = _preguntaActual.Texto;
            TextoDelResultado = string.Empty;

        }
        [RelayCommand]
        public void IrAPreguntaAnterior()
        {
            _preguntaActual = _preguntas.GetPreguntaAnterior();
            TextoDeLaPregunta = _preguntaActual.Texto;
            TextoDelResultado = string.Empty;
        }
        [RelayCommand]
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
    }
}
