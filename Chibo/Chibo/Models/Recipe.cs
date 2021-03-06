﻿using System;
using System.Collections.Generic;
using SQLite;

namespace Chibo.Models
{
    public class Recipe : IIdentifyable
    {
    private static Random _RNG = new Random();
    
    
        [PrimaryKey, AutoIncrement]
        private int id { get; set; }
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
        /// Gets or sets an array of strings. These strings act as tags to say what type of recipe this is. 
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

        public int ID
        {
            get;

            set;
        }

        public Recipe(string name, string[] instruction, string[] tag)
        {
            _ingredients = new ListIngredients();

            _name = name;

            _instruction = instruction;

            _tag = tag;
        }

        public Recipe()
        {
            //paramater-less constructor, only to be used by the database object so it knows what table layout to reference.
        }

        public Recipe(Recipe toCopy)
        {
            _ingredients = new ListIngredients();

            foreach (Ingredient i in toCopy.Ingredients.Ingredients)
            {
                _ingredients.Add(i);
            }

            _name = new string(toCopy.Name.ToCharArray());

            List<string> tempStringArray = new List<string>();

            int j = 0;
            while (j < toCopy.Instruction.Length)
            {
                tempStringArray.Add(new string(toCopy.Instruction[j].ToCharArray()));
                j += 1;
            }

            _instruction = tempStringArray.ToArray();

            tempStringArray = new List<string>();

            j = 0;
            while (j < toCopy.Tag.Length)
            {
                tempStringArray.Add(new string(toCopy.Tag[j].ToCharArray()));

                j += 1;
            }

            _tag = tempStringArray.ToArray();
        }

        public static Recipe RandomRecipe(string[] tags, double likenessPercentage)
        {
            Recipe[] toSelectFrom = new Recipe[] { };//false target, needs to be loaded from database

            if (likenessPercentage > 1.0)
            {
                likenessPercentage = 1.0;
            }

            List<Recipe> validChoices = new List<Recipe>();

            foreach (Recipe r in toSelectFrom)
            {
                if (r.FitsTags(tags) >= likenessPercentage)
                {
                    validChoices.Add(new Recipe(r));
                }
            }

            if (validChoices.Count == 0)
            {
                return null;
            }

            return validChoices[_RNG.Next(validChoices.Count)];
        }

        public void Add(Ingredient toAdd, float amount)
        {
            Ingredient toPass = new Ingredient(toAdd.Name, toAdd.Descrip, amount, toAdd.CaloriesPerGram);

            _ingredients.Add(toPass);
        }

        public void Remove(Ingredient toRemove, float amount)
        {
            Ingredient toPass = new Ingredient(toRemove.Name, toRemove.Descrip, amount, toRemove.CaloriesPerGram);

            _ingredients.Remove(toPass);
        }

        public double FitsTags(string[] tags)
        {
            int found = 0;

            foreach (string s in _tag)
            {
                foreach (string si in tags)
                {
                    if (s == si)
                    {
                        found += 1;
                        break;
                    }
                }
            }

            return Convert.ToDouble(found) / Convert.ToDouble(tags.Length);//percentage
        }

        public bool SameID(IIdentifyable identified)
        {
            bool result = false;

            if (this.GetType() == identified.GetType())
            {
                if (this.ID == identified.ID)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}