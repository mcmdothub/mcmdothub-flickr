// Dynamic Version Management
// Define the endpoint of your ASP.NET Core Web API
const apiVersion = 'v1.0';
const apiEndpoint = `https://localhost:7106/api/${apiVersion}/Photos/search`;

const photoSearchInput = document.querySelector('#photoSearch');
const welcomeArea = document.querySelector('.dynamically-generated-content');

// Initialize variables
let prevKeyword = '';
let debounceTimeout;
let currPage = 1;
let isLoading = false;
let allPhotos = [];

// Get reference to the loading modal
const loadingModal = document.getElementById('loadingModal');

// Show Loading Modal
function showLoadingModal() {
    loadingModal.classList.add('show');
}

// Hide Loading Modal
function hideLoadingModal() {
    loadingModal.classList.remove('show');
}

// Function to fetch photos from the API
async function fetchPhotos(query, page = 1) {
    showLoadingModal(); // Show loading modal before API call starts

    try {
        const response = await fetch(`${apiEndpoint}?text=${encodeURIComponent(query)}&perPage=12&page=${page}`);
        if (!response.ok) {
            throw new Error(`Failed to fetch: ${response.status}`);
        }
        const data = await response.json();
        return data.photos.photo; // Adjust according to the response structure
    } catch (error) {
        console.error('Error fetching photos:', error);
        alert('The server is unresponsive. Please try again later.'); // Optional: Show an alert
        return [];
    } finally {
        hideLoadingModal(); // Hide loading modal after API call finishes or fails
    }
}

// Function to generate dynamic content
function generateExploreContent(photos) {
    let exploreItemsHTML = '';

    photos.forEach((photo, index) => {
        exploreItemsHTML += `
            <div class="col-12 col-sm-6 col-lg-4 col-xl-3">
                <div class="explore-card card shadow-sm">
                    <div class="card-body">
                        <div class="img-wrap">
                            <img src="https://farm${photo.farm}.staticflickr.com/${photo.server}/${photo.id}_${photo.secret}.jpg" alt="${photo.title}">
                        </div>
                        <div class="row gx-2 align-items-center mt-2">
                            <div class="col-8">
                                <div class="name-info d-flex align-items-center">
                                    <div class="name-author">
                                        <a class="author name d-block hover-primary fw-bold text-truncate" href="#">${photo.title || 'Untitled'}</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        `;
    });

    return exploreItemsHTML;
}

// Function to handle search dynamically as user types
async function handleDynamicSearch(query) {
    if (query === prevKeyword) {
        return; // Avoid unnecessary API calls for the same keyword
    }

    prevKeyword = query;
    currPage = 1; // Reset to the first page for new search
    isLoading = false; // Reset loading state
    allPhotos = []; // Clear previously loaded photos

    if (query && query.length > 0) {
        const photos = await fetchPhotos(query, currPage);
        allPhotos = photos;

        if (photos.length > 0) {
            const newContent = `
                <div class="breadcrumb-wrapper">
                    <div class="container">
                        <div class="breadcrumb-content">
                            <h2 class="breadcrumb-title">Explore Results</h2>
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb justify-content-center">
                                    <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                                    <li class="breadcrumb-item active" aria-current="page">Explore</li>
                                </ol>
                            </nav>
                        </div>
                    </div>
                </div>
                <div class="divider"></div>
                <div class="explore-items-wrapper">
                    <div class="container">
                        <div class="row g-4 justify-content-center" id="explorePhotos">
                            ${generateExploreContent(photos)}
                        </div>
                    </div>
                </div>
            `;
            welcomeArea.innerHTML = newContent;
        } else {
            welcomeArea.innerHTML = `
                <div class="breadcrumb-wrapper">
                    <div class="container">
                        <div class="breadcrumb-content">
                            <h2 class="breadcrumb-title">Explore Results</h2>
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb justify-content-center">
                                    <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                                    <li class="breadcrumb-item active" aria-current="page">Explore</li>
                                </ol>
                            </nav>
                        </div>
                    </div>
                </div>
                <div class="divider"></div>
                <div class="explore-items-wrapper">
                    <div class="container">
                        <div class="row g-4 justify-content-center">
                            <div class="col-12 text-center">
                                <p class="text-muted fs-5">No results found for <span class="fw-bold">"${query}"</span>.</p>
                            </div>
                        </div>
                    </div>
                </div>
            `;
        }
    } else {
        
    }
}

// Function to load more photos when scrolling
async function loadMorePhotos() {
    if (!prevKeyword || isLoading) return;

    isLoading = true;
    currPage++;

    const morePhotos = await fetchPhotos(prevKeyword, currPage);
    if (morePhotos.length > 0) {
        allPhotos = allPhotos.concat(morePhotos);

        const explorePhotosContainer = document.querySelector('#explorePhotos');
        explorePhotosContainer.insertAdjacentHTML('beforeend', generateExploreContent(morePhotos));
    }
    isLoading = false;
}

// Debounce function to delay search calls
function debounce(func, delay) {
    return (...args) => {
        clearTimeout(debounceTimeout);
        debounceTimeout = setTimeout(() => func(...args), delay);
    };
}

// Add event listener for keyup on the search input
photoSearchInput.addEventListener(
    'keyup',
    debounce((event) => {
        const query = event.target.value.trim().toLowerCase();
        handleDynamicSearch(query);
    }, 500)
);

// Add event listener for scroll
window.addEventListener('scroll', () => {
    if (window.innerHeight + window.scrollY >= document.body.offsetHeight - 100 && !isLoading) {
        loadMorePhotos();
    }
});
