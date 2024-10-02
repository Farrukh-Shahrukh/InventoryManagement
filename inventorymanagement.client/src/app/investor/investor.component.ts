import { Component, ElementRef, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Investor } from '../../Models/investor.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { InvestorService } from '../../services/investor-service/investor.service';

@Component({
  selector: 'app-investor',
  templateUrl: './investor.component.html'
})
export class InvestorComponent {
  @ViewChild('ngbToast', { static: true }) ngbToast!: ElementRef;
  @ViewChild('updateModal') updateModal!: TemplateRef<any>;
  public investors: Investor[] = [];
  public selectedInvestor: Investor =  new Investor();
  public newInvestor: Investor =  new Investor();
  public isEditing: boolean = false;
  toastMessage: string = '';
  showToastFlag: boolean = false;
  toastType: string = '';
  public isLoading: boolean = false;

  constructor(
    private investorService: InvestorService,
    private modalService: NgbModal,
    private router: Router) { }

  ngOnInit(): void {
    this.loadInvestors();
  }

  loadInvestors(): void {
    this.isLoading = true;
    this.investorService.getInvestors().subscribe(
      (data: Investor[]) => {
        this.investors = data;
        this.isLoading = false;
      },
      error => {
        this.showToast('Error loading investors', 'error');
        this.isLoading = false;
      }
    );
  }

  saveInvestor() {
    this.investorService.createInvestor(this.newInvestor).subscribe(
      (newInvestor: Investor) => {
        this.investors.push(newInvestor);
        this.resetForm();
        this.showToast('Investor Added successfully!', 'success');
      },
      (error) => {
        console.error('Error creating Investor', error);
        this.showToast('Error creating Investor. Please try again.', 'error');
      }
    );
  }
  updateInvestor(modal: any) {
    this.investorService.updateInvestor(this.selectedInvestor.id, this.selectedInvestor).subscribe(
      response => {
        this.showToast('Investor updated successfully', 'success');
        modal.close();
        this.loadInvestors();
      },
      error => {
        this.showToast('Error updating Investor', 'error');
      }
    );
  }

  openUpdateModal(investor: Investor) {
    console.log(investor)
    this.selectedInvestor = { ...investor };
    this.modalService.open(this.updateModal);
    this.isEditing = true;
  }

  showToast(message: string, type: string) {
    this.toastMessage = message;
    this.toastType = type;
    this.showToastFlag = true;
    setTimeout(() => this.showToastFlag = false, 3000);
  }
  resetForm(): void {
    this.newInvestor = { name: '', cnic: '', id: 0};
    this.isEditing = false;
  }

  addInvestments(investor: Investor): void {
    this.router.navigate(['/investments'], {
      queryParams: { investorId: investor.id, investorName: investor.name }
    });
  }
}
