import requests

API_BASE_URL = "https://your-api-url.com/api/price"
API_KEY = ""

headers = {
    "X-Api-Key": API_KEY
}

def test_get_all_prices():
    response = requests.get(f"{API_BASE_URL}/all", headers=headers)
    print("GET All Prices:", response.status_code, response.json())

def test_get_prices_by_date_range():
    params = {
        "startDate": "2023-01-01",
        "endDate": "2023-12-31"
    }
    response = requests.get(f"{API_BASE_URL}/filter", headers=headers, params=params)
    print("GET Prices by Date Range:", response.status_code, response.json())

if __name__ == "__main__":
    test_get_all_prices()
    test_get_prices_by_date_range()
