function isSymmetric(arr) {
    if (!Array.isArray(arr)) {
        return false; // Non-arrays are non-symmetric    
    }
    let reversed = arr.slice(0).reverse(); // Clone and reverse    
    let equal = (JSON.stringify(arr) == JSON.stringify(reversed));
    return equal;
}

    module.exports = {
        isSymmetric
    }

    //in TEST new file

    // const{expect} = require('chai');
    // const{isSymmetric} = require('../05. Check for Symmetry');
    // describe('isSymmetryc',() => {
    //     it('should return false', () => {
    //         let input = 'Not Array';
    //         let result = isSymmetric(input);
    //         expect(result.to.be.false);
    //     });
            // it('should returm true', () => {

            // });
    // });