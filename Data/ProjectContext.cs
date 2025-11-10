namespace Data
{
    internal class ProjectContext
    {
        public object Blogs { get; internal set; }
        public object ResetPasswordCodes { get; internal set; }
        public object Employees { get; internal set; }
        public object Roles { get; internal set; }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
