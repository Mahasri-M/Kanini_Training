import { Component } from '@angular/core';

@Component({
  selector: 'app-mortgage-calculator',
  templateUrl: './mortgage-calculator.component.html',
  styleUrls: ['./mortgage-calculator.component.css']
})
export class MortgageCalculatorComponent {
  purchasePrice: number = 0;
  downPayment: number = 0;
  repaymentTime: number = 1;
  interestRate: number = 0;
  loanAmount: number = 0;
  monthlyPayment: number = 0;

  calculateMortgage() {
    this.loanAmount = this.purchasePrice - this.downPayment;
    const months = this.repaymentTime * 12;
    const monthlyInterestRate = this.interestRate / 100 / 12;
    const numerator = this.loanAmount * monthlyInterestRate;
    const denominator = 1 - Math.pow(1 + monthlyInterestRate, -months);
    this.monthlyPayment = numerator / denominator;
  }

  ngOnChanges() {
    this.calculateMortgage();
  }
}

