describe('My Tasks template', () => {
  it('should create the update screen', () => {
    cy.visit('http://localhost:4200/mystaskslist')
    cy.get('#btn-update').should('be.visible').should('be.enabled').click();
    cy.contains('Editar Tarefa').should('be.visible');
  })
})