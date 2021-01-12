describe('Test', () => {
    it('Test to click a card', () => {
        cy.visit("http://localhost").
            get('#magic-quote').should('not.exist').
            get('#card-a-image').should('not.exist').
            request('magiccards/last-fetched-pair').
            get('#card-a-vote-button').click().
            get('#card-a-vote-button').should('not.exist').
            get('#card-a-image').should('exist').
            get('#magic-quote').should('exist').
            get('#next-button').click().
            get('#card-a-vote-button').should('exist')
    })
})
it('Test last fetched', () => {
    cy.request('http://localhost/magiccards/last-fetched-pair');
})