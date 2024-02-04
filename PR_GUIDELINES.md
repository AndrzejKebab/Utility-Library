# Contribution Guidelines for Issues and Pull Requests

These guidelines aim to create an ecosystem fostering technical growth and instilling best practices in software development. Detailed issue tracking and disciplined pull request management form a foundation for robust code development and effective team dynamics, leading to more reliable and maintainable codebases.

## Opening an Issue on GitHub

All pull requests need to be associated with an Issue that clearly describes the feature or bugfix. 
If it is a bugfix, include steps to replicate the problem, describe the expected behaviour, as well as acceptance criteria.

1. Navigate to the "Issues" tab in the repository.
2. Click "New issue" and select a template or open a blank issue.
3. Provide a title and details. Use the examples at the end of this document as a guide.
4. Click "Submit new issue."

## Pull Request Guidelines

If an issue has been assigned to you and the work is ready for code review, open a Pull Request keeping in mind the points below.  The goal is to create Pull Requests that allow development in an agile manner - easy to read, easy to review.

- **Single Responsibility**: Each PR should address only one specific issue or feature.
- **Title and Description**: Provide a clear title and a detailed description.
- **Issue Linkage**: Link each PR to a related issue.
- **Branch Naming**: Consistent branch naming is useful for CI/CD pipelines.
  - Feature branches: `/feature/IssueNumber_Title`
  - Bugfix branches: `/bugfix/IssueNumber_Title`

Unless there is a valid reason for showing the steps taken to implement the PR, all PRs should be rebased onto the HEAD of the target branch and should be squashed to one commit for easy code review.

- **Squashing and Rebasing**:
  - **Squash Commits**: Use `git rebase -i <oldparent>`
  - **Rebase onto Target Branch**: Use `git rebase --onto <newparent> <oldparent>`

Read more about these git commands:
- [Git Squash Commits](https://www.freecodecamp.org/news/git-squash-commits/)
- [Git Rebase Onto](https://womanonrails.com/git-rebase-onto)

## Issue Examples

### #1 Example Feature Request

**Title**: Implement Reflection Extension Methods

**Description**
- Develop extension methods for Reflection to enhance usability and streamline common tasks.

**Details**
- **Extension Methods**: Create methods for common reflection operations, such as getting property values or invoking methods.
- **Ease of Use**: Focus on making the API more intuitive and less error-prone.
- **Documentation**: Provide clear, concise documentation for each extension method.

**Additional Notes**
This addition will cater to frequent requests for more developer-friendly reflection tools in our community forums.

### #2 Example Bugfix Issue

**Title**: Fix InvalidOperationException in Reflection Extension Method

**Description**
- There's an issue in our custom reflection extension method `GetPropertyValue<T>()` where it throws an `InvalidOperationException` under specific conditions.

**Replication Steps**
1. Invoke `GetPropertyValue<T>()` on an object where the property is of type `Nullable<int>` but has a `null` value.
2. The method throws an `InvalidOperationException` instead of returning `null`.

**Expected Behavior**
- The method should correctly return `null` when a nullable property's value is `null`.

**Acceptance Criteria**
1. `GetPropertyValue<T>()` returns `null` without throwing exceptions for nullable types with `null` values.
2. Ensure existing functionality for non-nullable types remains intact.
3. Add unit tests to cover this scenario.
