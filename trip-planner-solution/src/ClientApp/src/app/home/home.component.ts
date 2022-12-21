import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { NgbAccordionModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public forecasts: CityInfoDto[] = [];
  public selectedCity: CityInfoDto = {
    name: '',
    shortDescription: '',
    currentWeather: '',
    currentWeekWeather: ''
  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<CityInfoDto[]>('https://trip-planner-api20221220213642.azurewebsites.net/' + 'foo').subscribe(result => {
      this.forecasts = result;
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
