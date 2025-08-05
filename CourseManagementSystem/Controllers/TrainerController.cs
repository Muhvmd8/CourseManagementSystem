namespace CMS.PL.Controllers;


[Authorize(Roles = "Trainer")]
public class TrainerController
(
    ICourseService courseService,
    ILogger<TrainerController> logger,
    IWebHostEnvironment environment
) 
    : Controller

{

    #region Dashboard
    [HttpGet]
    public IActionResult Dashboard()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return BadRequest("Invalid Operation");
        var courses = courseService.GetAllByTrainerId(userId);
        // View Data For => Number of trainees in all courses
        ViewData["CountOfTrainees"] = courseService.NumberOfTraineesForTrainer(userId);
        return View(courses);
    } 
    #endregion

    #region Course Details
    [HttpGet]
    public IActionResult CourseDetails(int? id)
    {
        if (!id.HasValue) return NotFound();

        var course = courseService.GetById(id.Value);
        if (course is null) return NotFound("Course is not found");

        return View(course);
    } 
    #endregion

    #region Add Course
    [HttpGet]
    public IActionResult AddCourse() => View();
    [HttpPost]
    public IActionResult AddCourse(AddEditCourseViewModel viewModel)
    {
        // Server-side validation
        if (ModelState.IsValid)
        {
            try
            {
                // Mapping to CourseCreateRequest
                var request = new CourseCreateRequest
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Price = viewModel.Price,
                    Image = viewModel.Image,
                    Hours = viewModel.Hours,
                };
                // Store a trainer id
                request.TrainerId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
                // Add course
                var result = courseService.Add(request);
                if (result > 0)
                    return RedirectToAction(nameof(Dashboard));
                
                ModelState.AddModelError(string.Empty, "Course didn't added successfully.");
                return View(result);
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(viewModel);
                }
                else
                {
                    logger.LogError(ex.Message);
                    return View("ErrorView");
                }
            }
        }
        return View(viewModel);
    }
    #endregion

    #region Edit Course
    [HttpGet]
    public IActionResult EditCourse(int? id)
    {
        if (id is null) return NotFound();
        var course = courseService.GetById(id.Value);
        if (course is null) return NotFound();

        // Mapping to AddEditCourseViewModel
        var courseViewModel = new AddEditCourseViewModel
        {
            Title = course.Title,
            Description = course.Description,
            Price = course.Price,
            Hours= course.Hours,
            ImageName = course.ImageName, 
        };

        return View(courseViewModel);
    }
    [HttpPost]
    public IActionResult EditCourse([FromRoute]int? id, AddEditCourseViewModel viewModel)
    {
        if (!id.HasValue) return NotFound();
        // Server-side validation
        if (ModelState.IsValid)
        {
            try
            {
                // Mapping to CourseUpdateRequest
                var request = new CourseUpdateRequest
                {
                    Id = id.Value,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Price = viewModel.Price,
                    Hours = viewModel.Hours,
                    //ImageName = viewModel.ImageName,
                    Image = viewModel.Image,
                };
                // Store a trainer id
                request.TrainerId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
                var result = courseService.Update(request);
                if (result > 0)
                    return RedirectToAction(nameof(Dashboard));

                ModelState.AddModelError(string.Empty, "Course didn't updated successfully.");
                return View(result);
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(viewModel);
                }
                else
                {
                    logger.LogError(ex.Message);
                    return View("ErrorView");
                }
            }
        }
        return View(viewModel);
    }
    #endregion

    #region Delete Course
    [HttpPost]
    public IActionResult DeleteCourse(int? id)
    {
        if (!id.HasValue) return BadRequest();

        try
        {
            var isDeleted = courseService.Delete(id.Value);
            if (isDeleted) return RedirectToAction(nameof(Dashboard));

            ModelState.AddModelError(string.Empty, "Course didn't deleted successfully!");
            return View(nameof(CourseDetails), id.Value);
        }
        catch (Exception ex)
        {
            if(environment.IsDevelopment())
            {
                ModelState.AddModelError(string.Empty, "Course didn't deleted successfully!");
                return View(nameof(CourseDetails), id.Value);
            }
            logger.LogError(ex.Message);
            return View("ErrorView");
        }
    }
    #endregion

    // Number of registerd trainees in each course
}
