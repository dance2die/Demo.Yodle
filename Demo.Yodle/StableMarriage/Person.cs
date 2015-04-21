using System.Collections.Generic;

namespace StableMarriage
{
	class Person
	{
		private int _candidateIndex;
		public string Name { get; set; }
		public List<Person> Prefs { get; set; }
		public Person Fiance { get; set; }

		public Person(string name)
		{
			Name = name;
			Prefs = null;
			Fiance = null;
			_candidateIndex = 0;
		}
		public bool Prefers(Person p)
		{
			return Prefs.FindIndex(o => o == p) < Prefs.FindIndex(o => o == Fiance);
		}
		public Person NextCandidateNotYetProposedTo()
		{
			if (_candidateIndex >= Prefs.Count) return null;
			return Prefs[_candidateIndex++];
		}
		public void EngageTo(Person p)
		{
			if (p.Fiance != null) p.Fiance.Fiance = null;
			p.Fiance = this;
			if (Fiance != null) Fiance.Fiance = null;
			Fiance = p;
		}
	}
}