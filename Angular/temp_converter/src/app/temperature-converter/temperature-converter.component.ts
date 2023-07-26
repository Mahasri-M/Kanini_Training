import { Component } from '@angular/core';

@Component({
  selector: 'app-temperature-converter',
  templateUrl: './temperature-converter.component.html',
  styleUrls: ['./temperature-converter.component.css']
})
export class TemperatureConverterComponent {
  temperature: number | null = null;
  selectedUnit: string = 'Celsius';
  convertedTemperature: number | null = null;
  convertedUnit: string = '';

  validateInput() {
    const regex = /^[+-]?\d+(\.\d+)?$/;
    if (!regex.test(String(this.temperature))) {
      this.temperature = null;
    }
  }

  convertTemperature() {
    if (this.temperature !== null) {
      if (this.selectedUnit === 'Celsius') {
        this.convertedTemperature = (this.temperature * 9/5) + 32;
        this.convertedUnit = 'Fahrenheit';
      } else {
        this.convertedTemperature = (this.temperature - 32) * 5/9;
        this.convertedUnit = 'Celsius';
      }
    }
  }
}
