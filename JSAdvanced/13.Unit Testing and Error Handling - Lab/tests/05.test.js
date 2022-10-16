const { isSymmetric } = require('../05. Check for Symmetry');
const { expect } = require('chai');

describe('isSymmetryc', () => {
    it('should return false with string', () => {
        expect(isSymmetric('array')).to.be.false
    });
    it('should return false for type mismatched elements ', () => {
        expect(isSymmetric([1, 2, '1'])).to.be.false
    });
    it('should return false with nubers in not array', () => {
        expect(isSymmetric(1)).to.be.false
    });
    it('should return false for non-symmetric numeric array ', () => {
        expect(isSymmetric([1, 2, 3])).to.be.false
    });
    it('should return false with negative numbers non-symmetric', () => {
        expect(isSymmetric([-1, -2, -3, -4])).to.be.false
    });
    it('should return false with empty array', () => {
        expect(isSymmetric([])).to.be.true
    });
    it('should return true with string symmetric array', () => {
        expect(isSymmetric(['a', 'b', 'b', 'a'])).to.be.true
    });
    it('should return false with string in array', () => {
        expect(isSymmetric(['abba'])).to.be.true
    });
    it('should return true with odd length symmetric array ', () => {
        expect(isSymmetric([1, 2, 1])).to.be.true
    });
    it('should return true with negative numbers in symmetric array ', () => {
        expect(isSymmetric([-1, -2,, -2, -1])).to.be.true
    });
});