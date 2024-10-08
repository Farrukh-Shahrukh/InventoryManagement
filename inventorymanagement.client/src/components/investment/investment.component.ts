import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Investment } from '../../Models/investment.model';
import { InvestmentService } from '../../services/investment-service/investment.service';
import { InvestorService } from '../../services/investor-service/investor.service';
import { ActivatedRoute } from '@angular/router';
import { Investor } from '../../Models/investor.model';
import { ProjectService } from '../../services/project-service/project.service';
import { Project } from '../../Models/project.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-investment',
  templateUrl: './investment.component.html',
})
export class InvestmentComponent implements OnInit {
  @ViewChild('updateModal') updateModal!: TemplateRef<any>;
  public investments: Investment[] = [];
  public newInvestment: Investment = new Investment();
  public selectedInvestment: Investment = new Investment();
  public isEditing: boolean = false;
  public investorName: string = '';
  public investorId: number = 0;
  public investors: { id: number, name: string }[] = []; // For investor dropdown
  public projects: { id: number, name: string }[] = []; // For project dropdown
  toastMessage: string = '';
  showToastFlag: boolean = false;
  toastType: string = '';
  isLoading: boolean = false;

  constructor(
    private investmentService: InvestmentService,
    private investorService: InvestorService,
    private projectService: ProjectService,
    private route: ActivatedRoute,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.investorId = +params['investorId'];
      this.investorName = params['investorName'];
    });
    if (!this.investorId) {
      this.loadInvestors();
    }
    this.loadInvestments();
    this.loadProjects();
  }
  loadInvestors(): void {
    this.isLoading = true;
    this.investorService.getInvestors().subscribe(
      (data: Investor[]) => {
        this.investors= data.map(investor => ({ id: investor.id, name: investor.name }));
        this.isLoading = false;
      },
      error => {
        this.showToast('Error loading investors', 'error');
        this.isLoading = false;
      }
    );
  }
  loadProjects(): void {
    this.isLoading = true;
    this.projectService.getProjects().subscribe(
      (data: Project[]) => {
        this.projects = data.map(project => ({ id: project.id, name: project.name }));
        this.isLoading = false;
      },
      error => {
        this.showToast('Error loading projects', 'error');
        this.isLoading = false;
      }
    );
  }
  loadInvestments(): void {
    this.isLoading = true;
    this.investmentService.getInvestments().subscribe(
      (data: Investment[]) => {
        this.investments = data;
        if(this.investorId)
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
  openUpdateModal(investment: Investment): void {
    this.selectedInvestment = { ...investment };
    this.modalService.open(this.updateModal);
    this.isEditing = true;
  }
}
