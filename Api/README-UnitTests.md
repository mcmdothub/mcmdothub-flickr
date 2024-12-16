![Flickr Logo](https://combo.staticflickr.com/pw/images/flickr_logo_dots.svg)

# Unit Tests for `FlickrPhotosService`

This test project verifies the functionality of the **`FlickrPhotosService`**, ensuring it correctly interacts with the Flickr API, handles responses, and behaves as expected under various conditions.

---

## **Purpose of the Tests**

The tests are designed to validate the following:

1. **Valid API Response**: Ensure the service correctly deserializes a successful response from the Flickr API.
2. **Invalid JSON Handling**: Verify that the service handles malformed or unexpected JSON responses gracefully.
3. **API Error Handling**: Confirm the service throws appropriate exceptions when the API returns error responses (e.g., HTTP 500).
4. **Edge Cases**: Handle null or missing properties in the API response.

The tests use **mocking** to simulate API calls instead of making real HTTP requests, ensuring fast and reliable unit tests.

---

## **Technologies Used**

- **xUnit**: Testing framework for writing and executing tests.
- **Moq**: Mocking library to simulate `HttpClient` behavior.
- **FluentAssertions**: Provides fluent syntax for asserting test outcomes.
- **Microsoft.NET.Test.Sdk**: Test infrastructure for running .NET tests.

---

## **Prerequisites**

To run the tests, ensure you have the following installed:

- .NET SDK (Version 6.0 or later)
- NuGet packages:
  - `xunit`
  - `xunit.runner.visualstudio`
  - `Moq`
  - `FluentAssertions`
  - `Microsoft.NET.Test.Sdk`

---

## **How to Set Up**

1. Clone the repository:

   ```bash
   git clone https://github.com/your-repo-name.git
   cd your-repo-name
   ```

2. Navigate to the test project directory:

   ```bash
   cd tests/UnitTests
   ```

3. Restore dependencies:

   ```bash
   dotnet restore
   ```

---

## **How to Run the Tests**

Run the following command in the test project directory:

```bash
dotnet test
```

This will build the test project, discover the tests, and execute them. The results will indicate the number of tests passed, failed, or skipped.

---

## **Test Scenarios Covered**

### 1. **Valid API Response**

- **Test**: `SearchPhotosAsync_ReturnsValidResponse_WhenApiReturnsSuccess`
- **Description**: Verifies that a valid JSON response from the Flickr API is correctly deserialized into the `FlickrPhotoResponse` model.
- **Scenario**:
   - Input: Simulated API call with a valid response JSON.
   - Expected: Service returns a non-null result, and the response model contains the correct data.

---

### 2. **Invalid JSON Response**

- **Test**: `SearchPhotosAsync_ReturnsNull_WhenApiReturnsInvalidJson`
- **Description**: Ensures the service handles malformed JSON responses by returning `null`.
- **Scenario**:
   - Input: Simulated API call with invalid JSON.
   - Expected: Service returns `null` without throwing exceptions.

---

### 3. **API Error Response**

- **Test**: `SearchPhotosAsync_ThrowsException_WhenApiReturnsError`
- **Description**: Confirms that the service throws an appropriate exception when the API returns an error (e.g., HTTP 500).
- **Scenario**:
   - Input: Simulated API call with HTTP 500 response.
   - Expected: Service throws an `HttpRequestException`.

---

## **Example Output**

Running `dotnet test` should produce output similar to:

```
Test Run Successful.
Total tests: 3
     Passed: 3
     Failed: 0
     Skipped: 0
```

---

## **Troubleshooting**

1. **Test Discovery Issues**:
   Ensure the test adapter is installed:

   ```bash
   dotnet add package xunit.runner.visualstudio
   dotnet add package Microsoft.NET.Test.Sdk
   ```

2. **HTTP Mocking Issues**:
   - Verify that the `HttpMessageHandler` is mocked correctly using `Moq.Protected`.
   - Check for correct setup of responses.

3. **FluentAssertions Errors**:
   Ensure that the `FluentAssertions` package is installed:

   ```bash
   dotnet add package FluentAssertions
   ```

---

## **Additional Notes**

- The service uses **strongly-typed models** to ensure JSON responses map correctly to C# objects.
- External dependencies (like HTTP calls) are **mocked** to avoid flaky tests and ensure fast execution.

---

## **Contributing**

Contributions are welcome! If you find any issues or have suggestions for improvements:

1. Fork the repository.
2. Create a new branch.
3. Submit a pull request.

---

## **License**

This project is licensed under the MIT License.
