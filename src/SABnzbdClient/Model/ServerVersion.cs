namespace SABnzbdClient.Model
{
    public class ServerVersion
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Revision { get; set; }
        public int Build { get; set; }
        public string Version { get; set; }

        public void ExtractVersionAttributes()
        {
            var parts = Version.Split('.');

            var major = 0;
            if (parts.Length > 0)
                int.TryParse(parts[0], out major);

            var minor = 0;
            if (parts.Length > 1)
                int.TryParse(parts[1], out minor);

            var revision = 0;
            if (parts.Length > 2)
                int.TryParse(parts[2], out revision);

            var build = 0;
            if (parts.Length > 3)
                int.TryParse(parts[3], out build);

            Major = major;
            Minor = minor;
            Revision = revision;
            Build = build;
        }
    }
}
