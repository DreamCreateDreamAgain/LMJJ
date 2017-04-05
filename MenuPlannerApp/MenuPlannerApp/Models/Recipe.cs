﻿using System;
using System.Collections.Generic;

namespace Chibo.Models
{
	public class Recipe
	{
		private ListIngredients _ingredients;

		private string _name;

		private string[] _instruction;

		private string[] _tag;

		public string Name
		{
			get
			{
				return _name;
			}

			set
			{
				_name = value;
			}
		}

		public string[] Instruction
		{
			get
			{
				return _instruction;
			}

			set
			{
				_instruction = value;
			}
		}

		/// <summary>
		/// Gets or sets an array of strings. These strign act as tags to say what type of recipe this is. 
		/// (e.g. lunch, dinner, brunch)
		/// </summary>
		public string[] Tag
		{
			get
			{
				return _tag;
			}

			set
			{
				_tag = value;
			}
		}

		public ListIngredients Ingredients
		{ 
            // The ListIngredients type should provide functionality to manipulate itself
            // New ListIngredients never need to be assigned
			get
            {
                return _ingredients;
            }

		}

		public Recipe(string name, string[] instruction, string[] tag)
		{
			ListIngredients _ingredients = new ListIngredients();

			_name = name;

			_instruction = instruction;

			_tag = tag;
		}

        public void Add(Ingredient toAdd, /*AMOUNT*/)
        {
            _ingredients.Add(toAdd);
        }

        public void Remove(Ingredient toRemove, /*AMOUNT*/)
        {
            _ingredients.Remove(toRemove);
        }
	}
}