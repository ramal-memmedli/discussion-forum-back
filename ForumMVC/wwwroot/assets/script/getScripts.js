var topCommunitiesSection = document.getElementById("topCommunitiesSection");

async function getTopCommunities() {
    let topCommunitiesResponse = await fetch("/home/GetTopCommunities");
    let topCommunitiesData = await topCommunitiesResponse.text();

    topCommunitiesSection.innerHTML += topCommunitiesData;
}

getTopCommunities();
