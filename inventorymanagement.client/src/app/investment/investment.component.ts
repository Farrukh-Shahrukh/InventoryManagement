import { Component, OnInit } from '@angular/core';
import { Investment } from '../../Models/investment.model';
import { InvestmentService } from '../../services/investment-service/investment.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-investment',
  templateUrl: './investment.component.html',
})
export class InvestmentComponent implements OnInit {
  public investments: Investment[] = [];
  public newInvestment: Investment = new Investment();
  public isEditing: boolean = false;
  public investorName: string = '';
  public investorId: number = 0;
  toastMessage: string = '';
  showToastFlag: boolean = false;
  toastType: string = '';
  isLoading: boolean = false;

  constructor(
    private investmentService: InvestmentService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.investorId = +params['investorId'];
      this.investorName = params['investorName'];
    });
    this.loadInvestments();
  }

  loadInvestments(): void {
    this.isLoading = true;
    this.investmentService.getInvestments().subscribe(
      (data: Investment[]) => {
        this.investments = data.filter(investment => investment.investorId === this.investorId);
        this.isLoading = false;
      },
      error => {
        this.showToast('Error loading investments', 'error');
        this.isLoading = false;
      }
    );
  }

  saveInvestment() {
    this.newInvestment.investorId = this.investorId; // Set the investor ID
    this.investmentService.createInvestment(this.newInvestment).subscribe(
      (newInvestment: Investment) => {
        this.investments.push(newInvestment); // Add the newly created investment to the list
        this.resetForm(); // Reset the form fields
        this.showToast('Investment added successfully!', 'success');
      },
      (error) => {
        console.error('Error creating investment', error);
        this.showToast('Error creating investment. Please try again.', 'error');
      }
    );
  }
  updateInvestment(modal: any) {
    this.investmentService.updateInvestment(this.newInvestment.id, this.newInvestment).subscribe(
      (updatedInvestment: Investment) => {
        this.showToast('Investment updated successfully!', 'success');
        modal.close(); // Close the modal
        this.loadInvestments(); // Reload the investments list
      },
      (error) => {
        console.error('Error updating investment', error);
        this.showToast('Error updating investment. Please try again.', 'error');
      }
    );
  }
  editInvestment(investment: Investment): void {
    this.newInvestment = { ...investment };
    this.isEditing = true;
  }

  deleteInvestment(id: number): void {
    this.investmentService.deleteInvestment(id).subscribe(
      () => {
        this.showToast('Investment deleted successfully', 'success');
        this.loadInvestments();
      },
      error => this.showToast('Error deleting investment', 'error')
    );
  }

  resetForm(): void {
    this.newInvestment = new Investment();
    this.isEditing = false;
  }

  showToast(message: string, type: string): void {
    this.toastMessage = message;
    this.toastType = type;
    this.showToastFlag = true;
    setTimeout(() => this.showToastFlag = false, 3000);
  }
}
