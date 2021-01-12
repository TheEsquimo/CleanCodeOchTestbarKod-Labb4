describe('Test', () => {
    it('Test to click a card', () => {
        cy.visit("http://localhost").
            get('#magic-quote').should('not.exist').
            get('#card-a').click().
            get('#magic-quote').should('exist').
            get('#next-button').click()
    })
})
