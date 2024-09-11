describe('My Tasks template', () => {
  it('should create the list screen', () => {
    cy.visit('http://localhost:4200/mystaskslist')
    cy.get('#btn-add')
    .should('be.visible') // Verifica se o elemento é visível
    .should('be.enabled'); // Verifica se o botão está habilitado para cliques
  })
})