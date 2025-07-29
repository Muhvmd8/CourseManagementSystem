namespace CMS.DAL.Data.Context.Configurations;
internal class EnrollmentConfigurations : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(t => new 
        { 
            t.CourseId, 
            t.TraineeId 
        });

        builder.HasOne(t => t.Trainee)
            .WithMany(u => u.Enrollments)
            .HasForeignKey(e => e.TraineeId);

        builder.HasOne(t => t.Course)
            .WithMany(u => u.Enrollments)
            .HasForeignKey(e => e.CourseId);

        builder.Property(e => e.EnrollmentDate)
            .HasDefaultValueSql("GETDATE()");
    }
}
