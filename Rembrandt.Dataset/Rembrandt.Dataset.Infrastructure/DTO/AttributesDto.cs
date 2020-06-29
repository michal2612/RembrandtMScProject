namespace Rembrandt.Dataset.Infrastructure.DTO
{
    public class AttributesDto
    {
        public int? Lively { get; set; }
        public int? Relaxing { get; set; }
        public int? Tranquil { get; set; }
        public int? Noisy { get; set; }
        public int? Crowded { get; set; }
        public int? Safe { get; set; }
        public int? Beauty { get; set; }
        public int? Biodiversity { get; set; }
        public int? Trees { get; set; }
        public int? Shrubs { get; set; }
        public int? Lawns { get; set; }
        public int? Flowers { get; set; }
        public int? Natveg { get; set; }
        public int? Benches { get; set; }
        public int? Play { get; set; }
        public int? Sports { get; set; }
        public int? Garbage { get; set; }
        public int? Veget { get; set; }
        public int? Paths { get; set; }
        public int? Facilities { get; set; }

        public AttributesDto()
        {
            
        }

        public AttributesDto(int? lively, int? relaxing, int? tranquil, int? noisy, int? crowded, int? safe, int? beauty, int? biodiversity, int? trees, int? shrubs, int? lawns, int? flowers, int? natveg, int? benches, int? play,  int? sports, int? garbage, int? veget, int? paths, int? facilities)
        {
            Lively = lively;
            Relaxing = relaxing;
            Tranquil = tranquil;
            Noisy = noisy;
            Crowded = crowded;
            Safe = safe;
            Beauty = beauty;
            Biodiversity = biodiversity;
            Trees = trees;
            Shrubs = shrubs;
            Lawns = lawns;
            Flowers = flowers;
            Natveg = natveg;
            Benches = benches;
            Play = play;
            Sports = sports;
            Garbage = garbage;
            Veget = veget;
            Paths = paths;
            Facilities = facilities;
        }
    }
}