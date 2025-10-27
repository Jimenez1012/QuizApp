
namespace QuizApp.Models
{
    public class BancoDePreguntas
    {
        private List<Pregunta> _preguntas;
        private int _indicePreguntaActual;

        public BancoDePreguntas()
        {
            _preguntas = new List<Pregunta>();
            CargarPreguntas();
            _indicePreguntaActual = 0;
        }

        public Pregunta GetPrimeraPregunta()
        {
            _indicePreguntaActual = 0;
            return _preguntas[_indicePreguntaActual];
        }

        public Pregunta GetSiguientePregunta()
        {
            if (_indicePreguntaActual < _preguntas.Count - 1)
            {
                _indicePreguntaActual++;
            }
            else
            {
                _indicePreguntaActual = 0;
            }
            return _preguntas[_indicePreguntaActual];
        }

        public Pregunta GetPreguntaAnterior()
        {
            if (_indicePreguntaActual > 0)
            {
                _indicePreguntaActual--;
            }
            else
            {
                _indicePreguntaActual = _preguntas.Count - 1;
            }
            return _preguntas[_indicePreguntaActual];
        }
        private void CargarPreguntas()
        {
            _preguntas.Add(new Pregunta
            {
                Texto = "¿La peninsula de Yucatan se encuentra al norte de Mexico?",
                RespuestaEsCierto = false,

            });

            _preguntas.Add(new Pregunta
            {
                Texto = "¿El oceano Atlantico es el oceano mas grande del mundo?",
                RespuestaEsCierto = false,

            });

            _preguntas.Add(new Pregunta
            {
                Texto = "¿Gabriel Garcia Marquez escribio Cien Años de Soledad?",
                RespuestaEsCierto = true,

            });
        }

    }
}
