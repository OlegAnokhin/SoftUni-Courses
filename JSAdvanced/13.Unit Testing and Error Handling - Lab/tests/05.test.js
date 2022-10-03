const { isSymmetric } = require('..05. Check for Symmetry');
//const { expect } = require('chai');
describe('isSymmetryc', () => {
    it('should return false', () => {
        let input = 'Not Array';
        let result = isSymmetric(input);
        expect(result.to.be.false);
    });
    it('should return true', () => {

    });
});