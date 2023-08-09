﻿using Demo2.Entity;

namespace Demo2.Models.ResponseModel
{
    public class PokemonResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public bool IsShiny { get; set; }

    }
}
