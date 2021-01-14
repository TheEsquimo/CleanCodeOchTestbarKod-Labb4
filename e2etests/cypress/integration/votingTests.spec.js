describe('Test magic card pair voting system', () => {
    it('Check that HTML elements to be shown before vote does not exist', () => {
        cy.visit("http://localhost").
            get('#magic-quote').should('not.exist').
            get('#card-a-image').should('not.exist');
    })

    it('Check that voting on a card works and registers correctly in API database', () => {
        let cardPairBeforeVote;
        cy.visit("http://localhost").
            request('localhost:5000/magiccards/last-fetched-pair').
                then(response => {
                    cardPairBeforeVote = response.body;
                }).
                get('#card-a-vote-button').click().
                request('localhost:5000/magiccards/last-fetched-pair').
                then(response => {
                    expect(response.body).property('cardAVotes').to.equal(cardPairBeforeVote.cardAVotes + 1);
                }).
                request('PUT', 'localhost:5000/magiccards/undo-last-vote?cardThatWasVotedOn=a').
                get('#card-a-vote-button').should('not.exist').
                get('#card-a-image').should('exist').
                get('#magic-quote').should('exist').
                get('#next-button').click().
                get('#card-a-vote-button').should('exist');
    })
})