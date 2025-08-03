namespace CMS.DAL.Data.Context.Configurations;
internal class CourseConfigurations : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(c => c.Title)
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Description)
            .HasColumnType("varchar")
            .HasMaxLength(1000);

        builder.Property(c => c.Price)
            .HasColumnType("decimal(10,3)");

        #region Relationship between trainer and course
        builder.HasOne(c => c.Trainer)
            .WithMany(t => t.Courses)
            .HasForeignKey(c => c.TrainerId)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion
    }
}
