using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using lab1;

namespace lab4
{
    public class ExperimentEntity
    {
        public int Id { get; set; }
        public List<CardEntity> Deck { get; set; }
    }

    public enum CardColorEntity
    {
        Red,
        Black
    }
}
