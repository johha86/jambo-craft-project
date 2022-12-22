import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public cities: CityInfoDto[] = [];
  public selectedCity: CityInfoDto = {
    name: '',
    shortDescription: '',
    currentWeather: '',
    currentWeekWeather: ''
  };

  constructor(http: HttpClient) {
    http.get<TripPlannerDto>(`${environment.apiURL}City`).subscribe(result => {
      this.cities = result.citiesInfo;
    }, error => console.error(error));
  }

  public OnSelectCity(city: CityInfoDto): void {
    this.selectedCity = city;
  }
}

interface CityInfoDto {
  name: string;
  shortDescription: string;
  currentWeather: string;
  currentWeekWeather: string;
}

interface TripPlannerDto {
  citiesInfo:CityInfoDto[]
}

