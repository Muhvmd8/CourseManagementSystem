namespace CMS.PL.Controllers;
public class TrainerController
(
    ICourseService courseService,
    ILogger<TrainerController> logger,
    IWebHostEnvironment environment
) 
    : Controller

{
    [HttpGet]
    public IActionResult Dashboard() // index
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return BadRequest("Invalid Operation");
        var courses = courseService.GetAllByTrainerId(userId);
        // View Data For => Number of trainees in all courses
        ViewData["CountOfTrainees"] = courseService.NumberOfTraineesForTrainer(userId);
        return View(courses);
    }

    #region Add Course
    [HttpGet]
    public IActionResult AddCourse() => View();
    [HttpPost]
    public IActionResult AddCourse(CourseCreateRequest request)
    {
        // Server-side validation
        if (ModelState.IsValid)
        {
            try
            {
                // Add course
                var result = courseService.Add(request);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Dashboard));
                }
                ModelState.AddModelError(string.Empty, "Course didn't added successfully.");
                return View(result);
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(request);
                }
                else
                {
                    logger.LogError(ex.Message);
                    return View("ErrorView");
                }
            }
        }
        return View(request);
    }
    #endregion

    #region Edit Course
    [HttpGet]
    public IActionResult EditCourse(int? id)
    {
        if (id is null) return BadRequest();
        var course = courseService.GetById(id.Value);
        if (course is null) return BadRequest();
        return View(course);
    }
    [HttpPost]
    public IActionResult EditCourse(CourseUpdateRequest request)
    {
        // Server-side validation
        if (ModelState.IsValid)
        {
            try
            {
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
                    return View(request);
                }
                else
                {
                    logger.LogError(ex.Message);
                    return View("ErrorView");
                }
            }
        }
        return View(request);
    }
    #endregion

    #region Delete Course

    #endregion

    // Number of registerd trainees in each course

}
